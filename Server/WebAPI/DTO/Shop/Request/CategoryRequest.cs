using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class CategoryRequest
  {

    [Required]
    public int ServerId { get; set; }
    [Required]
    public string RuTitle { get; set; }
    public string EnTitle { get; set; }

  }
}
