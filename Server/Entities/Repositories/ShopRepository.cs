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
      var server = await _repositoryContext.GameServers
                    .FirstOrDefaultAsync(gs => gs.Title.ToLower().Equals(gameServer.Title));

      if(server == null)
      {
        await _repositoryContext.GameServers.AddAsync(gameServer);
        _repositoryContext.SaveChanges();

        return server;
      }

      return null;
    }

    public async Task<GameServer> EditGameServerAsync(string newTitle, string oldTitle)
    {
      var server = await _repositoryContext.GameServers
                    .FirstOrDefaultAsync(gs => gs.Title.ToLower().Equals(oldTitle.ToLower()));

      if (server != null)
      {
        server.Title = newTitle.ToLower();
        server.UpdatedAt = DateTimeOffset.UtcNow;

        _repositoryContext.SaveChanges();
        return server;
      }

      return null;
    }

    public async Task<bool> RemoveGameServerAsync(GameServer gameServer)
    {
      var server = await _repositoryContext.GameServers
                    .FirstOrDefaultAsync(gs => 
                        gs.Title.ToLower().Equals(gameServer.Title.ToLower()));

      if (server != null)
      {
        _repositoryContext.GameServers.Remove(server);
        _repositoryContext.SaveChanges();
        return true;
      }

      return false;
    }


    // <---------- Category ---------->


    public async Task<bool> CreateCategoryAsync(Category category)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> EditCategoryAsync(Category category)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> RemoveCategoryAsync(Category category)
    {
      throw new NotImplementedException();
    }


    // <---------- Item ---------->


    public async Task<bool> CreateItemAsync(Item item)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> EditItemAsync(Item item)
    {
      throw new NotImplementedException();
    }

    public async Task<bool> RemoveItemAsync(Item item)
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
