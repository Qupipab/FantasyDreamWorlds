using Entities.Models;
using Entities.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
  public class ShopRepository : IShopRepository
  {


    // <---------- GameServer ---------->


    public Task<bool> CreateGameServerAsync(GameServer gameServer)
    {
      throw new NotImplementedException();
    }

    public Task<bool> EditGameServerAsync(GameServer gameServer)
    {
      throw new NotImplementedException();
    }

    public Task<bool> RemoveGameServerAsync(GameServer gameServer)
    {
      throw new NotImplementedException();
    }


    // <---------- Category ---------->


    public Task<bool> CreateCategoryAsync(Category category)
    {
      throw new NotImplementedException();
    }

    public Task<bool> EditCategoryAsync(Category category)
    {
      throw new NotImplementedException();
    }

    public Task<bool> RemoveCategoryAsync(Category category)
    {
      throw new NotImplementedException();
    }


    // <---------- Item ---------->


    public Task<bool> CreateItemAsync(Item item)
    {
      throw new NotImplementedException();
    }

    public Task<bool> EditItemAsync(Item item)
    {
      throw new NotImplementedException();
    }

    public Task<bool> RemoveItemAsync(Item item)
    {
      throw new NotImplementedException();
    }
  }
}
