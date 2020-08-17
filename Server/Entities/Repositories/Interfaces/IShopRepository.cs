using Entities.Models;
using System;
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
    Task<ICollection<GameServer>> GetGameServersAsync();

    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> EditCategoryAsync(int categoryId, string newRuTitle, string newEnTitle);
    Task<bool> RemoveCategoryAsync(int categoryId);
    Task<ICollection<Category>> GetCategoriesAsync(int gameServerId);

    Task<Item> CreateItemAsync(Item newItem, int categoryId);
    Task<Item> EditItemAsync(Item editItem);
    Task<bool> RemoveItemAsync(Guid itemId);
    IQueryable<Item> GetItems(int serverId, int categoryId, string ItemsForSearch, ItemsSortType sortType, Language language);

    Task<ItemCategory> CreateItemCategoryAsync(ItemCategory itemCategory);

    Task<bool> IsGameServerExistsAsync(int gameServerId);
    Task<bool> IsCategoryExistsAsync(int categoryId);

  }
}
