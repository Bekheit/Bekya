using UserService.Dtos;
using UserService.Models;

namespace UserService.Data;

public interface IUserRepo
{
  Task<IEnumerable<User>> GetUsers();
  Task<User> GetUserById(int id);
  void AddUser(User user);

  bool SaveChanges();
}