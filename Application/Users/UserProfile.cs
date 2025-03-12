using Application.Users.Commands.CreateNewUserCommand;
using AutoMapper;
using Domain.Entities.User;

namespace Application.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateNewUserCommand, MainUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
