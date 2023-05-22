using AutoMapper;
using AutoMapper.QueryableExtensions;
using UserService.Dtos;
using UserService.Models;

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

  public void AddUser(User user)
  {
    _context.Add(user);
  }

  public async Task<User> GetUserById(int id)
  {
    var user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    return user;
  }

  public async Task<IEnumerable<User>> GetUsers()
  {
    return await _context
                .Users
                .ToListAsync();
  }

  public bool SaveChanges()
  {
    return _context.SaveChanges() >= 0;
  }
}
