using System;
using System.ComponentModel.DataAnnotations;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Dtos;

public record class StudyDetailDto(

  [Required] int Id,
  [Required][StringLength(50)] string Title,
  [Required] string Description,
  [Required] string Category,
  [Required] int MaxNumber,
  [Required][StringLength(50)] string Place,
  [Required] int UserId,
  [Required] DateTime Date,
  [Required] string UserName
);

