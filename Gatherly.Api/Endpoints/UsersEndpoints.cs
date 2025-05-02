using System;
using Gatherly.Api.Data;
using Gatherly.Api.Dtos;
using Gatherly.Api.Entities;
using Gatherly.Api.Mapping;

namespace Gatherly.Api.Endpoints;

public static class UsersEndpoints
{
  const string GetUsersEndpointsName = "GetUser";

  public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
  {
    var group = app.MapGroup("/user").WithParameterValidation();

    // GET /user/{id}
    group.MapGet("/{id}", async (int id, GatherlyContext dbContext) => {
      User ? user = await dbContext.Users.FindAsync(id);
      return user is null ? Results.NotFound() : Results.Ok(user.ToUserDetailsDto());
    }).WithName(GetUsersEndpointsName);

    // POST /user
    group.MapPost("/", async (CreateUserDto newUser, GatherlyContext dbContext) => {
        User user = newUser.ToEntity();

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();

        return Results.CreatedAtRoute(
          GetUsersEndpointsName, new { id = user.Id },
          user.ToUserDetailsDto()
        );
    }).WithParameterValidation();


  return group;
  }

}
