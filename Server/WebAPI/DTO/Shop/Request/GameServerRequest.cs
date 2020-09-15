using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class GameServerRequest
  {

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Title { get; set; }

  }
}
