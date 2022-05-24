using PlayerFlowX.ApplicationServices.Requests.User;
using System.Threading.Tasks;

namespace PlayerFlowX.ApplicationServices.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateRequest UserUpdateRequest);
    }
}
