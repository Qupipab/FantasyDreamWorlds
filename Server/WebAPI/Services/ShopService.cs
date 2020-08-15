using AutoMapper;
using Entities.Models;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DTO.Pagination.Request;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{

  public class ShopService : IShopService
  {

    private readonly IShopRepository _shopRepository;
    private readonly IMapper _mapper;

    public ShopService(IShopRepository shopRepository, IMapper mapper)
    {
      _shopRepository = shopRepository;
      _mapper = mapper;
    }


    // <---------- GameServer ---------->


    public async Task<GameServerResponse> CreateGameServerAsync(GameServerRequest gameServerRequest, string creatorId)
    {
      var dateNow = DateTimeOffset.UtcNow;

      var gameServer = _mapper.Map<GameServer>(gameServerRequest);

      gameServer.CreatorId = Guid.Parse(creatorId);
      gameServer.CreatedAt = dateNow;
      gameServer.UpdatedAt = dateNow;

      var createdGameServer = await _shopRepository.CreateGameServerAsync(gameServer);

      if(createdGameServer != null)
      {
        return _mapper.Map<GameServerResponse>(createdGameServer);
      }

      return null;
    }
    
    public Task<GameServerResponse> EditGameServerAsync(GameServerRequest createGameServerRequest)
    {
      throw new NotImplementedException();
    }

    public Task<GameServerResponse> RemoveGameServerAsync(GameServerRequest createGameServerRequest)
    {
      throw new NotImplementedException();
    }


    // <---------- Category ---------->


    public Task<CategoryResponse> CreateCategoryAsync(CategoryRequest categoryRequest)
    {
      throw new NotImplementedException();
    }

    public Task<CategoryResponse> EditCategoryAsync(CategoryRequest categoryRequest)
    {
      throw new NotImplementedException();
    }

    public Task<CategoryResponse> RemoveCategoryAsync(CategoryRequest categoryRequest)
    {
      throw new NotImplementedException();
    }


    // <---------- Item ---------->


    public Task<ItemResponse> CreateItemAsync(TransformItemRequest itemRequest)
    {
      throw new NotImplementedException();
    }

    public Task<ItemResponse> EditItemAsync(TransformItemRequest itemRequest)
    {
      throw new NotImplementedException();
    }

    public Task<ItemResponse> RemoveItemAsync(TransformItemRequest itemRequest)
    {
      throw new NotImplementedException();
    }

    public async Task<ICollection<ItemResponse>> GetItemsAsync(GetItemsRequest getItemsRequest, PaginationQuery paginationQuery = null)
    {

      var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);

      var items = await _shopRepository
        .GetItemsAsync(getItemsRequest.ServerId,
                       getItemsRequest.CategoryId,
                       getItemsRequest.ItemsForSearch.ToLower(),
                       getItemsRequest.SortType,
                       getItemsRequest.Language,
                       paginationFilter);

      var itemsResponse = _mapper.Map<ICollection<ItemResponse>>(items);

      return itemsResponse;
    }

  }
}
