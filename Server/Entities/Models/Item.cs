using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
  public class Item
  {

    [Key]
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public string RuTitle { get; set; }
    public string EnTitle { get; set; }
    public string Icon { get; set; }
    public int Count { get; set; }
    public int Coins { get; set; }
    public int ECoins { get; set; }
    public double Discount { get; set; }
    public DateTime DiscountEndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ICollection<ItemCategory> ItemCategories { get; set; }

  }
}
