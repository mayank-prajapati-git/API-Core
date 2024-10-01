using NagrajTea.Core.Models;
using NagrajTea.Repository.IRepository;
using NagrajTea.Service.IServices;

namespace NagrajTea.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel?> ValidateUser(string email)
        {
            return await _userRepository.ValidateUser(email);
        }
        public async Task<UserTokenModel?> GenerateToken(UserViewModel model)
        {
            return await _userRepository.GenerateToken(model);
        }
        public async Task<List<UserViewModel>> GetUserList()
        {
            return await _userRepository.GetUserList();
        }

        public async Task<UserViewModel?> GetUserDetail(long userId)
        {
            return await _userRepository.GetUserDetail(userId);
        }
    }
}
