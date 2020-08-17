using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Request
{
  public class EditItemRequest
  {

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string RuTitle { get; set; }

    [Required]
    public string EnTitle { get; set; }

    [Required]
    public string Icon { get; set; }

    [Required, Range(1, 256)]
    public int Count { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int Coins { get; set; }

    [Required, Range(1, int.MaxValue)]
    public int ECoins { get; set; }

    [Range(0, 1)]
    public double Discount { get; set; }

    [Required]
    public DateTimeOffset DiscountEndDate { get; set; }

  }
}
