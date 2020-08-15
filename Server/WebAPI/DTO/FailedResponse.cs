using System.Collections.Generic;

namespace WebAPI.DTO
{
  public class FailedResponse
  {

    public IEnumerable<string> Errors { get; set; }

  }
}
