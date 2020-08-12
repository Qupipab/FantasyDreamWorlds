using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
  public interface IShopRepository
  {

    Task<bool> CreateGameServerAsync(GameServer gameServer);
    Task<bool> EditGameServerAsync(GameServer gameServer);
    Task<bool> RemoveGameServerAsync(GameServer gameServer);


    Task<bool> CreateCategoryAsync(Category category);
    Task<bool> EditCategoryAsync(Category category);
    Task<bool> RemoveCategoryAsync(Category category);


    Task<bool> CreateItemAsync(Item item);
    Task<bool> EditItemAsync(Item item);
    Task<bool> RemoveItemAsync(Item item);

  }
}
