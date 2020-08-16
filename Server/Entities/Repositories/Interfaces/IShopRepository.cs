using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Repositories.Interfaces
{
  public interface IShopRepository
  {

    Task<GameServer> CreateGameServerAsync(GameServer gameServer);
    Task<GameServer> EditGameServerAsync(string newTitle, string oldTitle);
    Task<bool> RemoveGameServerAsync(GameServer gameServer);


    Task<bool> CreateCategoryAsync(Category category);
    Task<bool> EditCategoryAsync(Category category);
    Task<bool> RemoveCategoryAsync(Category category);


    Task<bool> CreateItemAsync(Item item);
    Task<bool> EditItemAsync(Item item);
    Task<bool> RemoveItemAsync(Item item);
    IQueryable<Item> GetItems(int serverId, int categoryId, string ItemsForSearch, ItemsSortType sortType, Language language);

  }
}
