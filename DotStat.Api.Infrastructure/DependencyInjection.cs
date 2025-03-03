using System.Text;
using DotStat.Api.Application.Common.Interfaces.Authentication;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Infrastructure.Auth;
using DotStat.Api.Infrastructure.Configuration;
using DotStat.Api.Infrastructure.Persistance;
using DotStat.Api.Infrastructure.Persistance.Interceptors;
using DotStat.Api.Infrastructure.Persistance.Repositories;
using DotStat.Api.Infrastructure.Common.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace DotStat.Api.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(
    this IServiceCollection services,
    ConfigurationManager configuration)
  {
    services.AddPersistance(configuration)
      .AddAuth(configuration);

    return services;
  }

  public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
  {
    var jwtSettings = new JwtSettings();
    configuration.Bind(JwtSettings.SectionName, jwtSettings);

    services.AddSingleton(Options.Create(jwtSettings));
    services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    services.AddHttpContextAccessor();

    services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
      });

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
        o =>
        {
          o.MigrationsHistoryTable(tableName: "__DotStatApiMigrationHistory", schema: "dotstatapi");
          o.SchemaBehavior(MySqlSchemaBehavior.Translate, (schema, entity) => $"{schema ?? "dbo"}_{entity}");
        }
      )
    );

    services.AddSingleton<ILocalStorageService, LocalStorageService>();
    services.AddScoped<PublishDomainEventsInterceptor>();
    services.AddScoped<IDeveloperRepository, DeveloperRepository>();
    services.AddScoped<IComplexRepository, ComplexRepository>();
    services.AddScoped<IBuildingRepository, BuildingRepository>();
    services.AddScoped<IDistrictRepository, DistrictRepository>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IOrderRepository, OrderRepository>();
    services.AddScoped<IParseRepository, ParseRepository>();
    services.AddScoped<IFlatRepository, FlatRepository>();
    services.AddScoped<IParkingRepository, ParkingRepository>();
    services.AddScoped<IStorageRepository, StorageRepository>();
    services.AddScoped<ICommercialRepository, CommercialRepository>();

    return services;
  }

  public static IApplicationBuilder PrepareInfrastructure(this IApplicationBuilder app)
  {
    PrepareDB.Prepare(app);

    return app;
  }
}