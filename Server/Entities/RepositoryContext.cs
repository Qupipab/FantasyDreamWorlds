using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
  public class RepositoryContext : IdentityDbContext<User>, IRepositoryContext
  {

    public RepositoryContext(DbContextOptions<RepositoryContext> options)
      : base(options)
    {}

    public DbSet<GameServer> GameServers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ItemCategory> ItemCategories { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>()
        .Ignore(u => u.PhoneNumber)
        .Ignore(u => u.PhoneNumberConfirmed);

      modelBuilder.Entity<GameServer>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Category>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<Item>()
        .Property(i => i.Id)
        .ValueGeneratedOnAdd();

      modelBuilder.Entity<ItemCategory>()
        .HasKey(ic => new { ic.ItemId, ic.CategoryId });

      modelBuilder.Entity<ItemCategory>()
        .HasOne<Item>(iс => iс.Item)
        .WithMany(i => i.ItemCategories)
        .HasForeignKey(iс => iс.ItemId);

      modelBuilder.Entity<ItemCategory>()
        .HasOne<Category>(ic => ic.Category)
        .WithMany(c => c.ItemCategories)
        .HasForeignKey(ic => ic.CategoryId);

      modelBuilder.Seed();
    }
  }
}
