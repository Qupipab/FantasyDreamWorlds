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


    public async Task<Category> CreateCategoryAsync(Category newCategory)
    { 
      var category = await _repositoryContext.Categories
                  .Where(c => c.GameServerId.Equals(newCategory.GameServerId)
                              && (c.RuTitle.Equals(newCategory.RuTitle)
                              || c.EnTitle.Equals(newCategory.EnTitle)))
                  .FirstOrDefaultAsync();

      if (category == null)
      {
        await _repositoryContext.Categories.AddAsync(newCategory);
        _repositoryContext.SaveChanges();

        return newCategory;
      }

      return null;
    }

    public async Task<Category> EditCategoryAsync(int categoryId, string newRuTitle, string newEnTitle)
    {
      var category = await _repositoryContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

      if (category != null)
      {
        category.RuTitle = newRuTitle.ToLower();
        category.EnTitle = newEnTitle.ToLower();
        category.UpdatedAt = DateTimeOffset.UtcNow;

        _repositoryContext.SaveChanges();
        return category;
      }

      return null;
    }

    public async Task<bool> RemoveCategoryAsync(int categoryId)
    {
      var category = await _repositoryContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

      if (category != null)
      {
        _repositoryContext.Categories.Remove(category);
        _repositoryContext.SaveChanges();
        return true;
      }

      return false;
    }


    // <---------- Item ---------->


    public async Task<Item> CreateItemAsync(Item newItem, int categoryId)
    {
      var item = await _repositoryContext.Items
                    .Where(i => i.ItemCategories.Any(ic => ic.CategoryId.Equals(categoryId))
                                && (i.RuTitle.Equals(newItem.RuTitle)
                                || i.EnTitle.Equals(newItem.EnTitle)))
                    .FirstOrDefaultAsync();

      if (item == null)
      {
        await _repositoryContext.Items.AddAsync(newItem);
        _repositoryContext.SaveChanges();

        return newItem;
      }

      return null;
    }

    public async Task<Item> EditItemAsync(Item editItem)
    {
      var item = await _repositoryContext.Items.FirstOrDefaultAsync(i => i.Id == editItem.Id);

      if (item != null)
      {

        item.RuTitle = editItem.RuTitle;
        item.EnTitle = editItem.EnTitle;
        item.Icon = editItem.Icon;
        item.Count = editItem.Count;
        item.Coins = editItem.Coins;
        item.ECoins = editItem.ECoins;
        item.Discount = editItem.Discount;
        item.DiscountEndDate = editItem.DiscountEndDate;
        item.UpdatedAt = editItem.UpdatedAt;

        _repositoryContext.SaveChanges();
        return item;
      }

      return null;
    }

    public async Task<bool> RemoveItemAsync(Guid itemId)
    {
      var item = await _repositoryContext.Items.FirstOrDefaultAsync(i => i.Id == itemId);

      if (item != null)
      {
        _repositoryContext.Items.Remove(item);
        _repositoryContext.SaveChanges();
        return true;
      }

      return false;
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


    public async Task<ItemCategory> CreateItemCategoryAsync(ItemCategory itemCategory)
    {
      var isItemCategoryExist = await _repositoryContext.ItemCategories
                    .Where(ic => ic.CategoryId.Equals(itemCategory.CategoryId)
                                 && ic.ItemId.Equals(itemCategory.ItemId))
                    .AnyAsync();

      if (!isItemCategoryExist)
      {
        await _repositoryContext.ItemCategories.AddAsync(itemCategory);
        _repositoryContext.SaveChanges();

        return itemCategory;
      }

      return null;
    }


    public async Task<bool> IsGameServerExistsAsync(int gameServerId)
    {
      return await _repositoryContext.GameServers
        .AnyAsync(gs => gs.Id.Equals(gameServerId));
    }

    public async Task<bool> IsCategoryExistsAsync(int categoryId)
    {
      return await _repositoryContext.Categories
        .AnyAsync(c => c.Id.Equals(categoryId));
    }
  }
}
