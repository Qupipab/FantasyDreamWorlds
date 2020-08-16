using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO.Shop.Response
{
  public class CategoryResponse
  {

    public int Id { get; set; }
    public string RuTitle { get; set; }
    public string EnTitle { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public int GameServerId { get; set; }

  }
}
