using System;

namespace Gatherly.Api.Entities;

public class User
{
  public int Id { get; set; }

  public required string UserName { get; set; }

  public required string FullName { get; set; }

  public required string Description { get; set; }

  public required string Email { get; set; }

  public required string PasswordHash { get; set; }

  public required string? ProfileUrl { get; set; }

  public IReadOnlyList<Study>? StudyPost { get; set; }

}