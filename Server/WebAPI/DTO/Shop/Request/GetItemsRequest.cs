using Entities.Models;
using System.ComponentModel.DataAnnotations;
using WebAPI.DTO.Pagination.Request;

namespace WebAPI.DTO.Shop.Request
{
  public class GetItemsRequest
  {

    [Required]
    public int ServerId { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public string ItemsForSearch { get; set; }

    [Required, Range(0, 2)]
    public ItemsSortType SortType { get; set; }

    [Required, Range(0, 1)]
    public Language Language { get; set; }

    [Required]
    public PaginationQuery PaginationQuery { get; set; }

  }
}
