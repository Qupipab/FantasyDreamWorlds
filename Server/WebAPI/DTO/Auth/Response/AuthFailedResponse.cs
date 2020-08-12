using System.Collections.Generic;

namespace WebAPI.DTO.Auth.Response
{
  public class AuthFailedResponse
  {

    public IEnumerable<string> Errors { get; set; }

  }
}
