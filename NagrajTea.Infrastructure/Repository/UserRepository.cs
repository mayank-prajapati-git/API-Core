using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NagrajTea.Common.Constants;
using NagrajTea.Repository.IRepository;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using NagrajTea.Core.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace NagrajTea.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<UserRepository>();
        }

        public async Task<UserViewModel?> ValidateUser(string email)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@p_Email", email);

                    var result = await connection.QueryFirstOrDefaultAsync<UserViewModel>(DatabaseConstants.User.USP_ValidateUser, param, commandType: CommandType.StoredProcedure);

                    _logger.LogInformation("ValidateUser Called");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method: {methodName} exception at: {Date}", nameof(ValidateUser), DateTime.UtcNow);
            }
            return null;
        }

        public async Task<UserTokenModel?> GenerateToken(UserViewModel model)
        {
            try
            {
                DateTime expirationAt = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:EXPIRATION_MINUTES"]));
                string uniqueId = Guid.NewGuid().ToString();
                Claim[] claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,model.UserId.ToString()),  // User unique Id
                new Claim(JwtRegisteredClaimNames.Jti,uniqueId),   // JWT.ID
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),     // Token Issued At
                new Claim(ClaimTypes.NameIdentifier,model.Name),
                new Claim(ClaimTypes.Name,model.Email)
                };

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken tokenGeneration = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: expirationAt,
                    signingCredentials: signingCredentials
                    );

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                string token = tokenHandler.WriteToken(tokenGeneration);

                return new UserTokenModel
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    Email = model.Email,
                    Token = token
                };
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public async Task<List<UserViewModel>> GetUserList()
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString")))
                {
                    connection.Open();

                    var result = await connection.QueryAsync<UserViewModel>(DatabaseConstants.User.USP_GetUserList, null, commandType: CommandType.StoredProcedure);

                    _logger.LogInformation("GetUserList Called");
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method: {methodName} exception at: {Date}", nameof(GetUserList), DateTime.UtcNow);
            }
            return new List<UserViewModel>();
        }

        public async Task<UserViewModel?> GetUserDetail(long userId)
        {
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DbConnectionString")))
                {
                    connection.Open();

                    var param = new DynamicParameters();
                    param.Add("@p_UserId", userId);

                    var result = await connection.QueryFirstOrDefaultAsync<UserViewModel>(DatabaseConstants.User.USP_GetUserDetail, param, commandType: CommandType.StoredProcedure);

                    _logger.LogInformation("GetUserDetail Called");
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Method: {methodName} exception at: {Date}", nameof(GetUserDetail), DateTime.UtcNow);
            }
            return null;
        }
    }
}
