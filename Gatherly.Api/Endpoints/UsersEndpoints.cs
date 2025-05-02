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

    //PUT /user/{id}
    group.MapPut("/{id}", async (int id, UpdateUserDto updateUser, GatherlyContext dbContext) => {
      var existingUser = await dbContext.Users.FindAsync(id);

      if(existingUser is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingUser)
              .CurrentValues
              .SetValues(updateUser.ToEntity(id));

      await dbContext.SaveChangesAsync();
      return Results.NoContent();
    });

  return group;
  }

}
