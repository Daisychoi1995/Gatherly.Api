using System;
using Gatherly.Api.Data;
using Gatherly.Api.Dtos;
using Gatherly.Api.Entities;
using Gatherly.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gatherly.Api.Endpoints;

public static class StudiesEndpoints
{
  const string GetStudiesEndpointsName = "GetStudies";

  public static RouteGroupBuilder MapStudiesEndpoints(this WebApplication app) {
    var group = app.MapGroup("/studies").WithParameterValidation();

    // GET /studies
    group.MapGet("/", async (GatherlyContext dbContext) => 
      await dbContext.Studies
                  .Include(study => study.User)
                  .Select(study => study.ToStudyDetailsDto())
                  .AsNoTracking()
                  .ToListAsync()
    );

    // GET /studies/{id}
    group.MapGet("/{id}", async (int id, GatherlyContext dbContext) => {
      Study ? study = await dbContext.Studies.FindAsync(id);
      return study is null ? Results.NotFound() : Results.Ok(study.ToStudyDetailsDto());
    })
      .WithName(GetStudiesEndpointsName);

    // POST /studies
    group.MapPost("/", async(CreateStudyDto newStudy, GatherlyContext dbContext) => {
      Study study = newStudy.ToEnTity();

      dbContext.Studies.Add(study);
      await dbContext.SaveChangesAsync();

      return Results.CreatedAtRoute(
        GetStudiesEndpointsName, new { id = study.Id },
        study.ToStudyDetailsDto()
      );
    }).WithParameterValidation();

    return group;
  }
}
