using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Auth.Request
{
  public class AuthSignUpRequest
  {

    [Required]
    [StringLength(30, MinimumLength = 4)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 12)]
    public string Password { get; set; }

  }
}
