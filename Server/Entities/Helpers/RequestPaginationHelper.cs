using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Helpers
{
  public class RequestPaginationHelper
  {
    public static async Task<ICollection<T>> PaginateAsync<T>(IQueryable<T> query, PaginationFilter pagination)
    {
      var skip = (pagination.PageNumber - 1) * pagination.PageSize;
      var paginatedItems = query.Skip(skip).Take(pagination.PageSize);
      return await paginatedItems.ToListAsync();
    }
  }
}
