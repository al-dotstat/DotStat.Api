using System.Diagnostics;
using DotStat.Api.Rest.Common.Constants;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace DotStat.Api.Rest.Common.Errors;

public class DotStatProblemDetailsFactory : ProblemDetailsFactory
{
  private readonly ApiBehaviorOptions _options;

  public DotStatProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
  {
    _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
  }

  public override ProblemDetails CreateProblemDetails(
    HttpContext httpContext,
    int? statusCode = null,
    string? title = null,
    string? type = null,
    string? detail = null,
    string? instance = null)
  {
    statusCode ??= 500;

    var problemDetails = new ProblemDetails
    {
      Status = statusCode,
      Title = title,
      Type = type,
      Detail = detail,
      Instance = instance,
    };

    ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

    return problemDetails;
  }

  public override ValidationProblemDetails CreateValidationProblemDetails(
    HttpContext httpContext,
    ModelStateDictionary modelStateDictionary,
    int? statusCode = null,
    string? title = null,
    string? type = null,
    string? detail = null,
    string? instance = null)
  {
    if (modelStateDictionary is null)
    {
      throw new ArgumentNullException(nameof(modelStateDictionary));
    }

    statusCode ??= 400;

    var problemDetails = new ValidationProblemDetails(modelStateDictionary)
    {
      Status = statusCode,
      Type = type,
      Detail = detail,
      Instance = instance,
    };

    if (title is not null)
    {
      problemDetails.Title = title;
    }

    ApplyProblemDetailsDefaults(httpContext, problemDetails, statusCode.Value);

    return problemDetails;
  }

  private void ApplyProblemDetailsDefaults(HttpContext httpContext, ProblemDetails problemDetails, int statusCode)
  {
    problemDetails.Status ??= statusCode;

    if (_options.ClientErrorMapping.TryGetValue(statusCode, out var clientErrorData))
    {
      problemDetails.Title ??= clientErrorData.Title;
      problemDetails.Type ??= clientErrorData.Link;
    }

    var traceId = Activity.Current?.Id ?? httpContext?.TraceIdentifier;
    if (traceId is not null)
    {
      problemDetails.Extensions["traceId"] = traceId;
    }

    var errors = httpContext?.Items["errors"] as List<Error>;
    if (errors is not null)
      problemDetails.Extensions.Add(HttpContextItemKeys.Errors, errors.Select(e => e.Code));
  }
}