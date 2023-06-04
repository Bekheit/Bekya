using Microsoft.AspNetCore.Identity;

namespace UserService.Entities;

public class AppUser : IdentityUser
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string? Gender { get; set; }
  public DateTime? DateOfBirth { get; set; }
}