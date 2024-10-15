using System.Reflection;
using MediatR;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using DotStat.Api.Application.Common.Behaviors;
using DotStat.Api.Application.Common.Interfaces.Export;
using DotStat.Api.Application.Parsing.Export;

namespace DotStat.Api.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    services.AddSingleton<IExporter, ExcelExporter>();

    return services;
  }
}