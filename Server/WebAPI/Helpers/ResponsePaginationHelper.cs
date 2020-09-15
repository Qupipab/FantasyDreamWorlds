
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DTO.Pagination.Request;
using WebAPI.DTO.Pagination.Response;

namespace WebAPI.Helpers
{
  public class ResponsePaginationHelper
  {

    public static PagedResponse<T> CreatePaginatedResponse<T>(PaginationFilter pagination, ICollection<T> response, int totalCount)
    {

      if (pagination == null || pagination.PageSize < 1 || pagination.PageNumber < 1)
      {
        new PagedResponse<T>(response);
      }

      return new PagedResponse<T>
      {
        Data = response,
        PageNumber = pagination.PageNumber >= 1 ? pagination.PageNumber : (int?)null,
        PageSize = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null,
        TotalCount = totalCount,
        NextPage = totalCount - (pagination.PageSize * pagination.PageNumber) > 0,
        PreviousPage = pagination.PageNumber - 1 >= 1
      };
    }
  }
}
