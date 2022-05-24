using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlayerFlowX.API.Extensions;
using PlayerFlowX.ApplicationServices.Interfaces;
using PlayerFlowX.ApplicationServices.Requests.User;
using PlayerFlowX.ApplicationServices.Responses.User;
using PlayerFlowX.Business.Handlers.NotificationHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlayerFlowX.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [HttpGet("Find_User")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserUpdateRequest> Get()
        {
            var userName = User.GetUserName();
            return await this._accountService.GetUserByUserNameAsync(userName);
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserResponse> Post(UserSaveRequest saveRequest)
        {
            return await this._accountService.CreateAccountAsync(saveRequest);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserLoginResponse> Post(UserLoginRequest userLogin)
        {
            return await this._accountService.CheckUserPasswordAsync(userLogin.UserName, userLogin.Password); 
        }


        [HttpPost("Update_User")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
        public async Task<UserUpdateResponse> Put(UserUpdateRequest userUpdate)
        {
            var user = await this._accountService.GetUserByUserNameAsync(User.GetUserName());
            if (user == null) return new UserUpdateResponse { UserName = "Usuário", Message = "Usuário inválido" };

            return await this._accountService.UpdateAccountAsync(userUpdate);
        }
    }
}
