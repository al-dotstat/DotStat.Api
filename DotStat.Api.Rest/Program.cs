using DotStat.Api.Application;
using DotStat.Api.Infrastructure;
using DotStat.Api.Rest;
using Microsoft.Extensions.FileProviders;

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

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "StaticFiles")),
  RequestPath = "/StaticFiles"
});

app.MapSwagger();
app.MapHealthChecks("/healthz");
app.MapControllers();

app.Run();
