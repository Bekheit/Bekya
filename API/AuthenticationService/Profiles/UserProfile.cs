
using AuthenticationService.Dtos;
using AuthenticationService.Entities;
using AutoMapper;

namespace AuthenticationService.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<AppUser, RegisterDto>();
    CreateMap<RegisterDto, AppUser>()
      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.PhoneNumber));
  }
}
