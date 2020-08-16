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


    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> EditCategoryAsync(int categoryId, string newRuTitle, string newEnTitle);
    Task<bool> RemoveCategoryAsync(int categoryId);


    Task<bool> CreateItemAsync(Item item);
    Task<bool> EditItemAsync(Item item);
    Task<bool> RemoveItemAsync(Item item);
    IQueryable<Item> GetItems(int serverId, int categoryId, string ItemsForSearch, ItemsSortType sortType, Language language);

    Task<bool> IsGameServerExistsAsync(int gameServerId);

  }
}
