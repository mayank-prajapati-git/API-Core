using NagrajTea.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagrajTea.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<UserViewModel?> ValidateUser(string email);
        Task<UserTokenModel?> GenerateToken(UserViewModel model);
        Task<List<UserViewModel>> GetUserList();
        Task<UserViewModel?> GetUserDetail(long userId);
    }
}
