using System;

namespace WebAPI.DTO.Shop.Response
{
  public class ItemResponse
  {

    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public string RuTitle { get; set; }
    public string EnTitle { get; set; }
    public string Icon { get; set; }
    public int Count { get; set; }
    public int Coins { get; set; }
    public int ECoins { get; set; }
    public double Discount { get; set; }
    public DateTimeOffset DiscountStartDate { get; set; }
    public DateTimeOffset DiscountEndDate { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

  }
}
