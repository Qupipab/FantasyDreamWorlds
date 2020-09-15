using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.DTO.Pagination.Response;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;

namespace WebAPI.Services.Interfaces
{
  public interface IShopService
  {

    Task<ResponseResult<GameServerResponse>> CreateGameServerAsync(GameServerRequest gameServerRequest, string creatorId);
    Task<ResponseResult<GameServerResponse>> EditGameServerAsync(EditGameServerRequest editGameServerRequest);
    Task<ResponseResult<bool>> RemoveGameServerAsync(GameServerRequest createGameServerRequest);
    Task<ResponseResult<ICollection<GameServerResponse>>> GetGameServersAsync();

    Task<ResponseResult<CategoryResponse>> CreateCategoryAsync(CategoryRequest categoryRequest, string creatorId);
    Task<ResponseResult<CategoryResponse>> EditCategoryAsync(EditCategoryRequest editCategoryRequest);
    Task<ResponseResult<bool>> RemoveCategoryAsync(DeleteCategoryRequest categoryRequest);
    Task<ResponseResult<ICollection<CategoryResponse>>> GetCategoriesAsync(GetCategoryRequest categoryRequest);

    Task<ResponseResult<ItemResponse>> CreateItemAsync(ItemRequest itemRequest, string creatorId);
    Task<ResponseResult<ItemResponse>> EditItemAsync(EditItemRequest itemRequest);
    Task<ResponseResult<bool>> RemoveItemAsync(DeleteItemRequest itemRequest);
    Task<PagedResponse<ItemResponse>> GetPaginatedItemsAsync(GetItemsRequest getItemsRequest);

  }
}
