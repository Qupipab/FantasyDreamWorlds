using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Entities
{

  public static class ModelBuilderExtensions
  {

    private static readonly Random getrandom = new Random();

    public static int GetRandomNumber(int min, int max)
    {
      lock (getrandom)
      {
        return getrandom.Next(min, max);
      }
    }

    public static void Seed(this ModelBuilder modelBuilder)
    {

      var dateNow = DateTime.UtcNow;
      Guid creatorId = Guid.Parse("95024899-0ae4-4916-bdf4-7cd55c11128b");

      Guid[] itemsGuids = new Guid[200];

      for (int i = 0; i < itemsGuids.Length; i++)
      {
        itemsGuids[i] = Guid.NewGuid();
      }

      // Servers

      modelBuilder
        .Entity<GameServer>()
        .HasData(
          new GameServer { Id = -1, CreatorId = creatorId, Title = "infinity", CreatedAt = dateNow, UpdatedAt = dateNow },
          new GameServer { Id = -2, CreatorId = creatorId, Title = "unfinity", CreatedAt = dateNow, UpdatedAt = dateNow },
          new GameServer { Id = -3, CreatorId = creatorId, Title = "ozone", CreatedAt = dateNow, UpdatedAt = dateNow },
          new GameServer { Id = -4, CreatorId = creatorId, Title = "arcmagic", CreatedAt = dateNow, UpdatedAt = dateNow }
        );

      // Categories

      Category[] categories = new Category[10];

      for (int i = 0; i < categories.Length; i++)
      {
        categories[i] =
          new Category
          {
            Id = (i + 1) * -1,
            CreatorId = creatorId,
            RuTitle = "категория " + (i + 1) * -1,
            EnTitle = "category " + (i + 1) * -1,
            CreatedAt = dateNow,
            UpdatedAt = dateNow,
            GameServerId = GetRandomNumber(-4, 0)
          };
      }

      modelBuilder.Entity<Category>().HasData(categories);

     // Items

     Item[] items = new Item[10];

      for (int i = 0; i < items.Length; i++)
      {
        items[i] =
          new Item
          {
            Id = itemsGuids[i],
            CreatorId = creatorId,
            RuTitle = "предмет " + (i + 1) * -1,
            EnTitle = "item " + (i + 1) * -1,
            Icon = "icon",
            Count = GetRandomNumber(1, 11),
            Coins = GetRandomNumber(10, 101),
            Discount = 0,
            DiscountStartDate = dateNow,
            DiscountEndDate = dateNow,
            CreatedAt = dateNow,
            UpdatedAt = dateNow
          };
      }

      modelBuilder.Entity<Item>().HasData(items);

      // Items Categories

      ItemCategory[] itemsCategories = new ItemCategory[10];

      for (int i = 0; i < itemsCategories.Length; i++)
      {
        itemsCategories[i] =
          new ItemCategory
          {
            CategoryId = (i + 1) * -1,
            ItemId = itemsGuids[i]
          };
      }

      modelBuilder.Entity<ItemCategory>().HasData(itemsCategories);

    }
  }
}
