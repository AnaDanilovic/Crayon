using AutoMapper;
using CloudSales.Model.Dto;
using CloudSales.Model.Model;

namespace CloudSales.WebAPI.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(); 
            CreateMap<UserDto, User>(); 
                                        
        }
    }
}
