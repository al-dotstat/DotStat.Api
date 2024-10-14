using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Infrastructure.Configuration;
using DotStat.Api.Infrastructure.Persistance;
using DotStat.Api.Infrastructure.Persistance.Repositories;
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

    services.AddScoped<IDeveloperRepository, DeveloperRepository>();
    services.AddScoped<IComplexRepository, ComplexRepository>();
    services.AddScoped<IBuildingRepository, BuildingRepository>();
    services.AddScoped<IDistrictRepository, DistrictRepository>();

    return services;
  }
}