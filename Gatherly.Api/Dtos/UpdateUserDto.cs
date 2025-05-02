using System.ComponentModel.DataAnnotations;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Dtos;

public record class UpdateUserDto(
  [Required][StringLength(50)] string UserName,
  [Required][StringLength(50)] string FullName,
  [Required] string Description,
  [Required][StringLength(50)] string Email,
  [Required] string PasswordHash,
  string? ProfileUrl,
  IReadOnlyList<Study>? StudyPost
);

