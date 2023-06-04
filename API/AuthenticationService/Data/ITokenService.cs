using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.Entities;

namespace AuthenticationService.Data;

public interface ITokenService
{
  public string CreateToken(AppUser user);
}
