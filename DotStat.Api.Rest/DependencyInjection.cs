using System.Reflection;
using DotStat.Api.Rest.Common.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

namespace DotStat.Api.Rest;

public static class DependencyInjection
{
  public static IServiceCollection AddPresentation(this IServiceCollection services)
  {
    services.AddControllers();

    services.AddSingleton<ProblemDetailsFactory, DotStatProblemDetailsFactory>();

    var mapsterConfig = TypeAdapterConfig.GlobalSettings;
    mapsterConfig.Scan(Assembly.GetExecutingAssembly());
    services.AddSingleton(mapsterConfig);
    services.AddScoped<IMapper, ServiceMapper>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
      var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

      options.SwaggerDoc("v1", new OpenApiInfo
      {
        Version = "v1",
        Title = "DotStat API",
      });

      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
      });

      options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
        {
          new OpenApiSecurityScheme
          {
            Name = "Bearer",
            In = ParameterLocation.Header,
            Reference = new OpenApiReference
            {
              Id = "Bearer",
              Type = ReferenceType.SecurityScheme
            }
          },
          new List<string>()
        }
      });
    });

    return services;
  }
}