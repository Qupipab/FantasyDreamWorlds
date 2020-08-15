using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WebAPI.DTO.Request
{
  public class TransformItemRequest
  {

    [Required]
    public int ServerId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string RuTitle { get; set; }

    [Required]
    public string EnTitle { get; set; }

    public string Icon { get; set; }
    public int Count { get; set; }
    public int Coins { get; set; }
    public int ECoins { get; set; }
    public double Discount { get; set; }
    public DateTimeOffset DiscountEndDate { get; set; }

  }
}
