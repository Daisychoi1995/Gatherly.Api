using System;
using Gatherly.Api.Dtos;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Mapping;

public static class StudyMapping
{
  public static StudyDetailDto ToGameDetailDto(this Study study)
  {
    return new(
      study.Id,
      study.Title,
      study.Description,
      study.Category,
      study.MaxMember,
      study.Place,
      study.UserId,
      study.Date,
      study.User?.UserName ?? "Unknown" 
    );
  }
}
