using System;
using Gatherly.Api.Data;
using Gatherly.Api.Entities;
using Gatherly.Api.Mapping;

namespace Gatherly.Api.Endpoints;

public static class UsersEndpoints
{
  const string GetUsersEndpointsName = "GetUser";

  public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/user");

    group.MapGet("/{id}", async (int id, GatherlyContext dbContext) => {
      User ? user = await dbContext.Users.FindAsync(id);
      return user is null ? Results.NotFound() : Results.Ok(user.ToUserDetailsDto());
    }).WithName(GetUsersEndpointsName);

  return group;
  }

}
