using AutoMapper;
using WebAPI.DTO.Pagination.Request;
using Entities.Models;

namespace WebAPI.MappingProfiles
{
  public class RequestToModelProfile : Profile
  {
    public RequestToModelProfile()
    {
      CreateMap<PaginationQuery, PaginationFilter>();
    }
  }
}
