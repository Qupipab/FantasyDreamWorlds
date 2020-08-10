using System.Collections.Generic;

namespace WebAPI.DTO.Response
{
  public class AuthFailedResponse
  {

    public IEnumerable<string> Errors { get; set; }

  }
}
