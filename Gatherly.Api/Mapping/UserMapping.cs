using System;
using Gatherly.Api.Dtos;
using Gatherly.Api.Entities;

namespace Gatherly.Api.Mapping;

public static class UserMapping
{

  public static User ToEntity(this CreateUserDto user)
  {
    return new User() 
    {
      UserName = user.UserName,
      FullName = user.FullName,
      Description = user.Description,
      Email = user.Email,
      PasswordHash = user.PasswordHash,
      ProfileUrl = user.ProfileUrl
    };
  }

  public static User ToEntity(this UpdateUserDto user, int id)
  {
    return new User() 
    {
      Id = id,
      UserName = user.UserName,
      FullName = user.FullName,
      Description = user.Description,
      Email = user.Email,
      PasswordHash = user.PasswordHash,
      ProfileUrl = user.ProfileUrl,
      StudyPost = user.StudyPost
    };
  }
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
