using System.ComponentModel.DataAnnotations;

namespace Gatherly.Api.Dtos;

public record class CreateUserDto(
  [Required][StringLength(50)] string UserName,
  [Required][StringLength(50)] string FullName,
  [Required] string Description,
  [Required][StringLength(50)] string Email,
  [Required] string PasswordHash,
  string? ProfileUrl
);

