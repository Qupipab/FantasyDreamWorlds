﻿using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
  public class RepositoryContext : IdentityDbContext<User>
  {

    public RepositoryContext(DbContextOptions<RepositoryContext> options)
      : base(options)
    {
      Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<User>()
        .Ignore(u => u.PhoneNumber)
        .Ignore(u => u.PhoneNumberConfirmed);
    }
  }
}
  