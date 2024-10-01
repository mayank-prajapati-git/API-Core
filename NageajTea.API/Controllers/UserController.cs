using Microsoft.AspNetCore.Mvc;
using NagrajTea.Common.Constants;
using NagrajTea.Core;
using NagrajTea.Service.IServices;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using NagrajTea.Core.Models;

namespace NageajTea.API.Controllers
{
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [NonAction]
        [HttpGet]
        [Route($"{RouteConstants.User.GetUserList}")]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _userService.GetUserList();

            var successResponse = new ApiResponse<dynamic>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Data retrieved successfully",
                Data = result,
            };

            return Ok(successResponse);
        }

        [HttpGet]
        [Route($"{RouteConstants.User.GetUserDetail}")]
        public async Task<IActionResult> GetUserDetail(long userId)
        {
            var result = await _userService.GetUserDetail(userId);

            var successResponse = new ApiResponse<dynamic>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Data retrieved successfully",
                Data = result,
            };

            return Ok(successResponse);
        }

        [HttpPost]
        [Route($"{RouteConstants.User.SaveUser}")]
        public async Task<IActionResult> SaveUser(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            var result = await _userService.GetUserDetail(1);

            var successResponse = new ApiResponse<dynamic>
            {
                Code = (int)HttpStatusCode.OK,
                Message = "Data retrieved successfully",
                Data = result,
            };

            return Ok(successResponse);
        }
    }
}
