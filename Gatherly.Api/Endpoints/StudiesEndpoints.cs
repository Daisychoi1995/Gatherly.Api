using System;
using Gatherly.Api.Data;
using Gatherly.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gatherly.Api.Endpoints;

public static class StudiesEndpoints
{
  const string GetStudiesEndpointsName = "GetStudies";

  public static RouteGroupBuilder MapStudiesEndpoints(this WebApplication app) {
    var group = app.MapGroup("/studies").WithParameterValidation();

    // GET /study
    group.MapGet("/", async (GatherlyContext dbContext) => 
      await dbContext.Studies
                  .Include(study => study.User)
                  .Select(study => study.ToGameDetailDto())
                  .AsNoTracking()
                  .ToListAsync()
    );

    return group;
  }
}
