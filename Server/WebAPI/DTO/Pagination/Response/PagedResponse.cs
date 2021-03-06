﻿using System.Collections.Generic;

namespace WebAPI.DTO.Pagination.Response
{
  public class PagedResponse<T>
  {

    public PagedResponse(){}

    public PagedResponse(IEnumerable<T> data)
    {
      Data = data;
    }

    public IEnumerable<T> Data { get; set; }

    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? TotalCount { get; set; }
    public bool NextPage { get; set; }
    public bool PreviousPage { get; set; }

  }
}
