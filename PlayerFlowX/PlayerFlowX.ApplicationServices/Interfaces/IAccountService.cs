using Microsoft.AspNetCore.Identity;
using PlayerFlowX.ApplicationServices.Requests.User;
using PlayerFlowX.ApplicationServices.Responses.User;
using System.Threading.Tasks;

namespace PlayerFlowX.ApplicationServices.Interfaces
{
    public interface IAccountService
    {
        Task<bool> UserExistAsync(string userName);
        Task<UserUpdateRequest> GetUserByUserNameAsync(string userName);
        Task<UserLoginResponse> CheckUserPasswordAsync(string userName, string password);
        Task<UserResponse> CreateAccountAsync(UserSaveRequest userSave);
        Task<UserUpdateRequest> UpdateAccountAsync(UserUpdateRequest userUpdate);
    }
}
