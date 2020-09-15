using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class CategoryRequest
  {

    [Required]
    public int GameServerId { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string RuTitle { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string EnTitle { get; set; }

  }
}
