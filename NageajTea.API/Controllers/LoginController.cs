using Microsoft.AspNetCore.Mvc;
using NagrajTea.Common.Constants;
using NagrajTea.Core;
using NagrajTea.Service.IServices;
using System.Net;

namespace NageajTea.API.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route($"{RouteConstants.Account.Login}")]
        public async Task<IActionResult> Login(string email)
        {
            var result = await _userService.ValidateUser(email);

            if(result == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    Code = (int)HttpStatusCode.NotFound,
                    Message = "User not found",
                    Data = null
                });
            }

            var resultGenerateToken = await _userService.GenerateToken(result);

            var successResponse = new ApiResponse<dynamic>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Data retrieved successfully",
                Data = resultGenerateToken,
            };

            return Ok(successResponse);
        }
    }
}
