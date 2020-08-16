using Entities.Models;
using Entities.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Repositories
{
  public class ShopRepository : IShopRepository
  {

    private readonly IRepositoryContext _repositoryContext;

    public ShopRepository(IRepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;
    }


    // <---------- GameServer ---------->


    public async Task<GameServer> CreateGameServerAsync(GameServer gameServer)
    {
      var title = await _repositoryContext.GameServers
                    .FirstOrDefaultAsync(gs => gs.Title.ToLower().Equals(gameServer.Title));

      if(title == null)
      {
        await _repositoryContext.GameServers.AddAsync(gameServer);
        _repositoryContext.SaveChanges();

        return gameServer;
      }

      return null;
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

    public IQueryable<Item> GetItems(int serverId, int categoryId, string itemsForSearch, ItemsSortType sortType, Language language)
    {

      var items = _repositoryContext.Items
        .Where(i => i.ItemCategories.Any(ic => ic.Category.GameServer.Id.Equals(serverId)))
        .Where(i => categoryId != 0
                    ? i.ItemCategories.Any(ic => ic.Category.Id.Equals(categoryId))
                    : i.ItemCategories.Any())
        .Where(i => language.Equals(Language.En)
                    ? i.EnTitle.Contains(itemsForSearch)
                    : i.RuTitle.Contains(itemsForSearch));

      items = sortType switch
      {
        ItemsSortType.DescendingPrice => items.OrderByDescending(i => i.Coins),
        ItemsSortType.Discount => items.OrderByDescending(i => i.Discount),
        _ => items.OrderBy(i => i.Coins)
      };

      return items;
    }
  }
}
