
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO.Pagination.Request
{
  public class PaginationQuery
  {

    public PaginationQuery()
    {
      PageNumber = 1;
      PageSize = 20;
    }

    public PaginationQuery(int pageNumber, int pageSize)
    {
      PageNumber = pageNumber;
      PageSize = pageSize;
    }

    [Range(1, int.MaxValue)]
    public int PageNumber { get; set; }

    [Range(1, 50)]
    public int PageSize { get; set; }

  }
}
