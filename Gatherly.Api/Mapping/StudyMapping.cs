using System;
using Gatherly.Api.Dtos;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Mapping;

public static class StudyMapping
{
  public static Study ToEnTity(this CreateStudyDto study)
  {
    return new Study()
    {
      Title = study.Title,
      Description = study.Description,
      Category = study.Category,
      MaxMember = study.MaxMember,
      Place = study.Place,
      UserId = study.UserId,
      Date = study.Date
    };
  }

  public static Study ToEnTity(this UpdateStudyDto study, int id)
  {
    return new Study()
    {
      Id = id,
      Title = study.Title,
      Description = study.Description,
      Category = study.Category,
      MaxMember = study.MaxMember,
      Place = study.Place,
      UserId = study.UserId,
      Date = study.Date
    };
  }

  public static StudyDetailDto ToStudyDetailsDto(this Study study)
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
