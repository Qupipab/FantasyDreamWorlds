using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
  public interface IRepositoryContext
  {

    DbSet<GameServer> GameServers { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<ItemCategory> ItemCategories { get; set; }
    DbSet<Item> Items { get; set; }

    int SaveChanges();

  }
}
