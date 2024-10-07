using DotStat.Api.Rest.Common.Constants;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotStat.Api.Rest.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BaseController : ControllerBase
{
  protected IActionResult Problem(List<Error> errors)
  {
    if (errors.Count is 0)
      return Problem();

    if (errors.All(error => error.Type == ErrorType.Validation))
      return ValidationProblem(errors);

    HttpContext.Items[HttpContextItemKeys.Errors] = errors;

    return Problem(errors[0]);
  }

  private IActionResult Problem(Error error)
  {
    var statusCode = error.Type switch
    {
      ErrorType.Conflict => StatusCodes.Status409Conflict,
      ErrorType.Validation => StatusCodes.Status400BadRequest,
      ErrorType.NotFound => StatusCodes.Status404NotFound,
      ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
      _ => StatusCodes.Status500InternalServerError,
    };
    return Problem(statusCode: statusCode, title: error.Description);
  }

  private IActionResult ValidationProblem(List<Error> errors)
  {
    var modelStateDictionary = new ModelStateDictionary();

    foreach (var error in errors)
      modelStateDictionary.AddModelError(error.Code, error.Description);

    return ValidationProblem(modelStateDictionary);
  }
}