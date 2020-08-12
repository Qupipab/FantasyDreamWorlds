using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Auth.Request
{
  public class AuthSignInRequest
  {

    [Required]
    [StringLength(30, MinimumLength = 4)]
    public string UserNameOrEmail { get; set; }

    [Required]
    [MinLength(12)]
    public string Password { get; set; }

  }
}
