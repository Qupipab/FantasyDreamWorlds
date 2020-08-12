using Entities.Repositories.Interfaces;
using System.Threading.Tasks;
using WebAPI.DTO.Request;
using WebAPI.DTO.Shop.Request;
using WebAPI.DTO.Shop.Response;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{

  public class ShopService : IShopService
  {

    private readonly IShopRepository _shopRepository;

    public ShopService(IShopRepository shopRepository)
    {
      _shopRepository = shopRepository;
    }


    // <---------- GameServer ---------->


    public Task<GameServerResponse> CreateGameServerAsync(GameServerRequest createGameServerRequest)
    {
      throw new System.NotImplementedException();
    }
    
    public Task<GameServerResponse> EditGameServerAsync(GameServerRequest createGameServerRequest)
    {
      throw new System.NotImplementedException();
    }

    public Task<GameServerResponse> RemoveGameServerAsync(GameServerRequest createGameServerRequest)
    {
      throw new System.NotImplementedException();
    }


    // <---------- Category ---------->


    public Task<CategoryResponse> CreateCategoryAsync(CategoryRequest categoryRequest)
    {
      throw new System.NotImplementedException();
    }

    public Task<CategoryResponse> EditCategoryAsync(CategoryRequest categoryRequest)
    {
      throw new System.NotImplementedException();
    }

    public Task<CategoryResponse> RemoveCategoryAsync(CategoryRequest categoryRequest)
    {
      throw new System.NotImplementedException();
    }


    // <---------- Item ---------->


    public Task<ItemResponse> CreateItemAsync(ItemRequest itemRequest)
    {
      throw new System.NotImplementedException();
    }

    public Task<ItemResponse> EditItemAsync(ItemRequest itemRequest)
    {
      throw new System.NotImplementedException();
    }

    public Task<ItemResponse> RemoveItemAsync(ItemRequest itemRequest)
    {
      throw new System.NotImplementedException();
    }
  }
}
