using AutoMapper;
using Entities.Models;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;

namespace WebAPI.MappingProfiles
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Item, ItemResponse>();

      CreateMap<GameServerRequest, GameServer>();
      CreateMap<EditGameServerRequest, GameServer>()
        .ForMember(model => model.Title, opt => opt.MapFrom(dto => dto.NewTitle));

      CreateMap<GameServer, GameServerResponse>();
    }
  }
}
