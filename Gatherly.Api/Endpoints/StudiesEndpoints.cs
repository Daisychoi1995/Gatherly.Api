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

    // PUT /studies/{id}
    group.MapPut("/{id}", async (int id, UpdateStudyDto updateStudy, GatherlyContext dbContext) => {
      var existingStudy = await dbContext.Studies.FindAsync(id);

      if(existingStudy is null)
      {
        return Results.NotFound();
      }

      dbContext.Entry(existingStudy)
               .CurrentValues
               .SetValues(updateStudy.ToEnTity(id));

      await dbContext.SaveChangesAsync();
      return Results.NoContent();
    });

    // DELETE /studies/{id}
    group.MapDelete("/{id}", async (int id, GatherlyContext dbContext) => {
      await dbContext.Studies
              .Where(study => study.Id == id)
              .ExecuteDeleteAsync();
              
      return Results.NoContent();
    });

    return group;
  }
}
