using System.Reflection;
using DotStat.Api.Rest.Common.Errors;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
    });

    return services;
  }
}