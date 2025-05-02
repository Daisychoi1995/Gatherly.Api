using System.ComponentModel.DataAnnotations;

namespace Gatherly.Api.Dtos;

public record class UpdateStudyDto(
  [Required][StringLength(50)] string Title,
  [Required] string Description,
  [Required] string Category,
  [Required] int MaxMember,
  [Required][StringLength(50)] string Place,
  [Required] int UserId,
  [Required] DateTime Date
);

