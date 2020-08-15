
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DTO.Pagination.Request;
using WebAPI.DTO.Pagination.Response;

namespace WebAPI.Helpers
{
  public class PaginationHelper
  {

    public static PagedResponse<T> CreatePaginatedResponse<T>(PaginationQuery pagination, ICollection<T> response)
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
        NextPage = response.Count() > pagination.PageSize,
        PreviousPage = pagination.PageNumber - 1 >= 1
      };
    }
  }
}
