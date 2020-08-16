using AutoMapper;
using Entities.Helpers;
using Entities.Models;
using Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO.Pagination.Request;
using WebAPI.DTO.Pagination.Response;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;
using WebAPI.Helpers;
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

    public async Task<PagedResponse<ItemResponse>> GetPaginatedItemsAsync(GetItemsRequest getItemsRequest)
    {

      var paginationFilter = _mapper.Map<PaginationFilter>(getItemsRequest.PaginationQuery);

      var items = _shopRepository.GetItems(getItemsRequest.ServerId,
                                           getItemsRequest.CategoryId,
                                           getItemsRequest.ItemsForSearch.ToLower(),
                                           getItemsRequest.SortType,
                                           getItemsRequest.Language);

      var paginatedItems = await RequestPaginationHelper.PaginateAsync(items, paginationFilter);

      var itemsResponse = _mapper.Map<ICollection<ItemResponse>>(paginatedItems);

      return ResponsePaginationHelper.CreatePaginatedResponse(paginationFilter, itemsResponse, items.Count());
    }

  }
}
