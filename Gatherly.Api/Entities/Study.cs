using System;

namespace Gatherly.Api.Entities;

public class Study
{
  public int Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required string Category { get; set; }

  public required int MaxMember { get; set; }

  public required string Place { get; set; }

  public int UserId { get; set; }

  public required DateTime Date { get; set; }

  public  User? User { get; set; }
}
