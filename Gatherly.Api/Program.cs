using Gatherly.Api.Data;
using Gatherly.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString= builder.Configuration.GetConnectionString("Gatherly");
builder.Services.AddDbContext<GatherlyContext>(options => options.UseNpgsql(connString));

var app = builder.Build();
app.MapUsersEndpoints();

app.Run();
