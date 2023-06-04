using AuthenticationService.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Data;

public class DataContext : IdentityDbContext<AppUser>
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {

  }
}
