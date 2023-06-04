
using AutoMapper;
using UserService.Dtos;
using UserService.Entities;

namespace UserService.Profiles;

public class UsersProfile : Profile
{
  public UsersProfile()
  {
    CreateMap<AppUser, UserDto>();
  }
}
