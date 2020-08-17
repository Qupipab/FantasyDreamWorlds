using System.Collections.Generic;

namespace WebAPI.DTO
{
  public class ResponseResult<T>
  {

    public T Response { get; set; }
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; }

  }
}
