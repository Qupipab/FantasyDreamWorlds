using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Auth.Request
{
  public class CheckUserNameRequest
  {

    [Required]
    [StringLength(30, MinimumLength = 4)]
    public string UserName { get; set; }

  }
}
