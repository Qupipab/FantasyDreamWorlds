using AutoMapper;
using Entities.Models;
using WebAPI.DTO.Shop.Response;

namespace WebAPI.MappingProfiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Item, ItemResponse>();
      CreateMap<GameServer, GameServerResponse>();
    }
  }
}
