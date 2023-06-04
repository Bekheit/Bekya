using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using UserService.Entities;

namespace UserService.Data
{
  public class DataContext : IdentityDbContext<AppUser>
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

  }
}