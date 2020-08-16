using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO.Pagination.Request;
using WebAPI.DTO.Pagination.Response;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;

namespace WebAPI.Services.Interfaces
{
  public interface IShopService
  {

    Task<GameServerResponse> CreateGameServerAsync(GameServerRequest gameServerRequest, string creatorId);
    Task<GameServerResponse> EditGameServerAsync(EditGameServerRequest editGameServerRequest);
    Task<bool> RemoveGameServerAsync(GameServerRequest createGameServerRequest);

    Task<CategoryResponse> CreateCategoryAsync(CategoryRequest categoryRequest);
    Task<CategoryResponse> EditCategoryAsync(CategoryRequest categoryRequest);
    Task<CategoryResponse> RemoveCategoryAsync(CategoryRequest categoryRequest);

    Task<ItemResponse> CreateItemAsync(TransformItemRequest itemRequest);
    Task<ItemResponse> EditItemAsync(TransformItemRequest itemRequest);
    Task<ItemResponse> RemoveItemAsync(TransformItemRequest itemRequest);
    Task<PagedResponse<ItemResponse>> GetPaginatedItemsAsync(GetItemsRequest getItemsRequest);
  }
}
