
using System.Collections;

namespace AuthenticationService.Dtos;

public class Response
{
  public int Code { get; set; }
  public bool Success { get; set; }
  public string Message { get; set; }
  public object Body { get; set; }
}
