using System;
using System.ComponentModel.DataAnnotations;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Dtos;

public record class CreateStudyDto(
  [Required][StringLength(50)] string Title,
  [Required] string Description,
  [Required] string Category,
  [Required] int MaxMember,
  [Required][StringLength(50)] string Place,
  [Required] int UserId,
  [Required] DateTime Date
);

