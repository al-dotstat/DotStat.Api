using DotStat.Api.Infrastructure.Configuration;
using DotStat.Api.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotStat.Api.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    ConfigurationManager configuration)
  {
    services.AddPersistance(configuration);

    return services;
  }

  public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
  {
    var mySqlConfiguration = configuration.GetSection("MySQL").Get<MySQLConfiguration>() ?? throw new NullReferenceException("No MySQL configuration in settings file");

    services.AddDbContext<DotStatApiDbContext>(options =>
      options.UseMySql(
        configuration.GetConnectionString("MySQL"),
        new MySqlServerVersion(new Version(
            mySqlConfiguration.MajorVersion,
            mySqlConfiguration.MinorVersion,
            mySqlConfiguration.BuildVersion)),
        o => o.MigrationsHistoryTable(tableName: "__DotStatApiMigrationHistory", schema: "dotstatapi")
      )
    );

    return services;
  }
}