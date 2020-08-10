using System.Collections.Generic;

namespace WebAPI.DTO
{
  public class AuthenticationResult
  {

    public string Token { get; set; }
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }

  }
}
