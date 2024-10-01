using NagrajTea.Core.Models;

namespace NagrajTea.Service.IServices
{
    public interface IUserService
    {
        Task<UserViewModel?> ValidateUser(string email);
        Task<UserTokenModel?> GenerateToken(UserViewModel model);
        Task<List<UserViewModel>> GetUserList();
        Task<UserViewModel?> GetUserDetail(long userId);
    }
}
