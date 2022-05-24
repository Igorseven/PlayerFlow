using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayerFlowX.ApplicationServices.AutoMapperSettings;
using PlayerFlowX.ApplicationServices.Interfaces;
using PlayerFlowX.ApplicationServices.Requests.User;
using PlayerFlowX.ApplicationServices.Responses.User;
using PlayerFlowX.Business.Extensions;
using PlayerFlowX.Business.Interfaces.OthersContracts;
using PlayerFlowX.Business.Interfaces.RepositoryContract;
using PlayerFlowX.Domain.Enums;
using PlayerFlowX.Domain.Identity;
using System.Threading.Tasks;

namespace PlayerFlowX.ApplicationServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly INotificationHandler _notification;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager,
            INotificationHandler notification, IUserRepository userRepository, ITokenService tokenService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._notification = notification;
            this._userRepository = userRepository;
            this._tokenService = tokenService;
        }

        public async Task<UserLoginResponse> CheckUserPasswordAsync(string userName, string password)
        {
            

            var user = await this._userManager.Users
                .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());

            var loginResult = await this._signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!loginResult.Succeeded)
                this._notification.AddNotification("Login or Password", "Login ou password inválido.");

            var userUpdate = user.MapTo<User, UserUpdateRequest>();
            return new UserLoginResponse
            {
                UserName = user.UserName,
                Name = user.FirstName,
                Token = this._tokenService.CreateToken(userUpdate).Result
            };
        }

        public async Task<UserResponse> CreateAccountAsync(UserSaveRequest userSave)
        {
            if (await UserExistAsync(userSave.UserName))
                this._notification.AddNotification("Usuário", EMessage.Exist.Description().FormatTo("Usuário"));

            var user = userSave.MapTo<UserSaveRequest, User>();
            var result = await _userManager.CreateAsync(user, userSave.Password);

            if (!result.Succeeded || this._notification.HasNotification() == true)
            {
                this._notification.AddNotification("Create user", "Erro ao tentar criar Usuário.");
                return null;
            }
            else
            {
                var response = user.MapTo<User, UserResponse>();
                return response;
            }
        }

        public async Task<UserUpdateRequest> GetUserByUserNameAsync(string userName)
        {
            if (!await UserExistAsync(userName))
                this._notification.AddNotification("Usuário", EMessage.NotFound.Description().FormatTo("User"));
        

            var user = await this._userRepository.FindByUserNameAsync(userName);

            if (this._notification.HasNotification() == true)
                return null;
            else
            {
                var userUpdateRequest = user.MapTo<User, UserUpdateRequest>();
                return userUpdateRequest;
            }
        }

        public async Task<UserUpdateResponse> UpdateAccountAsync(UserUpdateRequest userUpdate)
        {
            var user = await this._userRepository.FindByUserNameAsync(userUpdate.UserName);
            if (user == null)
            {
                this._notification.AddNotification("Usuário", "Usuário inválido.");
                return null;
            }
                
            var token = await this._userManager.GeneratePasswordResetTokenAsync(user);
            var result = await this._userManager.ResetPasswordAsync(user, token, userUpdate.Password);

            var updateResult = await this._userRepository.UpdateAsync(user);

            if (result.Succeeded && updateResult)
            {
                var userReturn = await this._userRepository.FindByUserNameAsync(user.UserName);
                var userUpdateRequest = userReturn.MapTo<User, UserUpdateResponse>();
                return userUpdateRequest;
            }
            return null;
        }

        public async Task<bool> UserExistAsync(string userName) => await this._userManager.Users
            .AnyAsync(u => u.UserName == userName.ToLower());  
    }
}
