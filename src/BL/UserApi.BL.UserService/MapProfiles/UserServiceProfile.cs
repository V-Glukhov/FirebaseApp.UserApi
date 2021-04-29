using AutoMapper;
using UserApi.BL.Contracts.Dto;
using UserApi.DAL.Models;

namespace UserApi.BL.UserService.MapProfiles
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
            CreateMap<NewAppDto, User>();
        }
    }
}
