using UserService.Models;

namespace UserService.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
  }
}