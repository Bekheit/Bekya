using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Entities;

namespace UserService.Data;

public class UserRepo : IUserRepo
{
  private readonly DataContext _context;
  private readonly IMapper _mapper;
  public UserRepo(DataContext context, IMapper mapper)
  {
    _mapper = mapper;
    _context = context;
  }

  public async Task<AppUser> GetUserById(string id)
  {
    var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    return user;
  }

  public async Task<IEnumerable<AppUser>> GetUsers()
  {
    return await _context
                .Users
                .ToListAsync();
  }

  public bool SaveChanges()
  {
    return _context.SaveChanges() >= 0;
  }

  public Task<ActionResult> UpdateUser(UpdateUserDto updateUserDto)
  {
    throw new NotImplementedException();
  }

  public void UpdateUser(string id)
  {
    throw new NotImplementedException();
  }
}
