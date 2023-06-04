using UserService.Dtos;
using UserService.Entities;

namespace UserService.Data;

public interface IUserRepo
{
  Task<IEnumerable<AppUser>> GetUsers();
  Task<AppUser> GetUserById(string id);
  void UpdateUser(string id);

  bool SaveChanges();
}