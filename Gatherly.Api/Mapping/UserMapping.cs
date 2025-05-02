using System;
using Gatherly.Api.Dtos;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Mapping;

public static class UserMapping
{
  public static UserDetailsDto ToUserDetailsDto(this User user)
  {
    return new(
      user.Id,
      user.UserName,
      user.FullName,
      user.Email,
      user.Description,
      user.ProfileUrl,
      user.StudyPost
    );
  }
}
