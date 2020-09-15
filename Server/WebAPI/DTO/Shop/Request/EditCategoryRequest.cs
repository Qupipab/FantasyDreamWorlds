using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class EditCategoryRequest
  {

    [Required]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string NewRuTitle { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string NewEnTitle { get; set; }

  }
}
