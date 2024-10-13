using DotStat.Api.Application;
using DotStat.Api.Infrastructure;
using DotStat.Api.Rest;

var builder = WebApplication.CreateBuilder(args);

builder.Services
  .AddPresentation()
  .AddApplication()
  .AddInfrastructure(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/healthz");
app.MapControllers();

app.Run();
