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
      new Study
      { 
        Id = 1, 
        Title = "Let's study .NET",
        Description = "Study .NET together!",
        Category = ".NET, Blazor, Razor" ,
        MaxMember = 4,
        Place = "Dev Academy, New Market",
        UserId = 1,
        Date = new DateTime(2025, 5, 2, 0, 0, 0, DateTimeKind.Utc)
      }
    );

    modelBuilder.Entity<User>().HasData(
      new User
      { 
        Id = 1, 
        UserName = "Daisy",
        FullName = "DaisyChoi",
        Description = "Hello! I'm Daisy",
        Email = "daisy@daisy.com",
        PasswordHash = "1234",
        ProfileUrl = ""
      }
    );
  }
}

// dotnet ef migrations add SeedGenre --output-dir Data/Migrations