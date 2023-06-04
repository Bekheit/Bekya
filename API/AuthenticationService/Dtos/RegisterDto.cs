
using System.ComponentModel.DataAnnotations;

namespace AuthenticationService.Dtos;

public class RegisterDto
{
  [RegularExpression(@"^0(10|11|12|15)(\d{8})$", ErrorMessage = "Invalid Phone Number")]
  public string PhoneNumber { get; set; }
  public string Password { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public DateTime? DateOfBirth { get; set; }
  public string? Gender { get; set; }
}
