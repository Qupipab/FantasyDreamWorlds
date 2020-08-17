using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Shop.Request
{
  public class ItemRequest
  {

    [Required]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string RuTitle { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string EnTitle { get; set; }

    [Required]
    public string Icon { get; set; }

    [Required, Range(1, 256)]
    public int Count { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int Coins { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int ECoins { get; set; }

    [Required, Range(0, 1)]
    public double Discount { get; set; }

    [Required]
    public DateTimeOffset DiscountEndDate { get; set; }

  }
}
