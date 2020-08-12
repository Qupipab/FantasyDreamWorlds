using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;

namespace WebAPI.Services.Interfaces
{
  interface IShopService
  {

    Task<GameServerResponse> CreateGameServerAsync(GameServerRequest createGameServerRequest);
    Task<GameServerResponse> EditGameServerAsync(GameServerRequest createGameServerRequest);
    Task<GameServerResponse> RemoveGameServerAsync(GameServerRequest createGameServerRequest);


    Task<CategoryResponse> CreateCategoryAsync(CategoryRequest categoryRequest);
    Task<CategoryResponse> EditCategoryAsync(CategoryRequest categoryRequest);
    Task<CategoryResponse> RemoveCategoryAsync(CategoryRequest categoryRequest);


    Task<ItemResponse> CreateItemAsync(ItemRequest itemRequest);
    Task<ItemResponse> EditItemAsync(ItemRequest itemRequest);
    Task<ItemResponse> RemoveItemAsync(ItemRequest itemRequest);

  }
}
