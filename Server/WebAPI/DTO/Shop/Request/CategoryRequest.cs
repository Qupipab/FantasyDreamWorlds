using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class CreateCategoryRequest
  {

    [Required]
    public int ServerId { get; set; }
    [Required]
    public string RuTitle { get; set; }
    public string EnTitle { get; set; }

  }
}
