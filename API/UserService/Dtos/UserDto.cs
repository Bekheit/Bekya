using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Dtos
{
  public class UserDto
  {
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName
    {
      get { return $"{FirstName} {LastName}"; }
    }
    public string? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
  }
}