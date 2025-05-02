using System;
using Gatherly.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gatherly.Api.Data;

public class GatherlyContext(DbContextOptions<GatherlyContext> options)
      :DbContext(options)
{
  public DbSet<Study> Studies => Set<Study>();
  public DbSet<User> Users => Set<User>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Study>().HasData(
      new { 
        Id = 1, 
        Title = "Let's study .NET",
        Description = "Study .NET together!",
        Category = ".NET, Blazor, Razor" ,
        MaxMember = 4,
        Place = "Dev Academy, New Market",
        CreatorId = 1,
        Date = DateTime.Now
      }
    );

    modelBuilder.Entity<User>().HasData(
      new { 
        Id = 1, 
        UserName = "Daisy",
        FullName = "DaisyChoi",
        Description = "Hello! I'm Daisy",
        Email = "daisy@daisy.com",
        PasswordHash = "1234"
      }
    );
  }
}

// dotnet ef migrations add SeedGenre --output-dir Data/Migrations