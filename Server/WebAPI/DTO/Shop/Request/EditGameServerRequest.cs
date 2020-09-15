using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class EditGameServerRequest
  {

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string NewTitle { get; set; }

    [Required]
    public string OldTitle { get; set; }

  }
}
