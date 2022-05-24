using AutoMapper;
using PlayerFlowX.ApplicationServices.Requests.User;
using PlayerFlowX.ApplicationServices.Responses.User;
using PlayerFlowX.Domain.Identity;

namespace PlayerFlowX.ApplicationServices.AutoMapperSettings.EntitiesProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserSaveRequest>().ReverseMap();

            CreateMap<User, UserUpdateRequest>().ReverseMap();

            CreateMap<User, UserLoginRequest>().ReverseMap();

            CreateMap<User, UserLoginResponse>();

            CreateMap<User, UserUpdateResponse>();

            CreateMap<User, UserResponse>();
        }
    }
}
