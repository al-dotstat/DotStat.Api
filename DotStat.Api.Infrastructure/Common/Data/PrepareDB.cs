using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using DotStat.Api.Infrastructure.Persistance;

namespace DotStat.Api.Infrastructure.Common.Data;

public static class PrepareDB
{
  public static void Prepare(IApplicationBuilder app)
  {
    using var scope = app.ApplicationServices.CreateScope();
    var logger = scope.ServiceProvider.GetService<ILoggerFactory>()!.CreateLogger(nameof(PrepareDB));
    var dbContext = scope.ServiceProvider.GetService<DotStatApiDbContext>()!;
    Migrate(dbContext, logger);
  }

  private static void Migrate(DotStatApiDbContext context, ILogger logger)
  {
    try
    {
      logger.LogInformation("Starting database migration");
      context.Database.Migrate();
    }
    catch (Exception ex)
    {
      logger.LogCritical($"Could not migrate to database {ex.Message}");
      throw;
    }
  }
}