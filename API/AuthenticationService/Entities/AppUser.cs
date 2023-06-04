using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Entities;

public class AppUser : IdentityUser
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public string? Gender { get; set; }
  public DateTime? DateOfBirth { get; set; }
}
