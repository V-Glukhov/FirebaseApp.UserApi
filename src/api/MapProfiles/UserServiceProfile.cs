using AutoMapper;
using UserApi.BL.Contracts.Commands;
using UserApi.BL.Contracts.Dto;
using UserApi.Models;

namespace UserApi.MapProfiles
{
    /// <summary>
    /// Профиль для UserService
    /// </summary>
    public class UserServiceProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public UserServiceProfile()
        {
            CreateMap<RegisterModel, RegisterNewAppCommand>()
                .ForMember(dst => dst.Dto, opt => opt.MapFrom(src => src));

            CreateMap<RegisterModel, NewAppDto>();
        }
    }
}
