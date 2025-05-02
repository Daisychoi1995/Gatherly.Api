using System;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Dtos;

public record class UserDetailsDto(

  int Id,
  string UserName,
  string FullName,
  string Description,
  string Email,
  string? ProfileUrl,
  IReadOnlyList<Study>? PostedStudies
);

