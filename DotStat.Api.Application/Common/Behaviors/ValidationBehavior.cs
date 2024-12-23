using System.Reflection;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace DotStat.Api.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IValidator<TRequest>? validator = null) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IErrorOr
{

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    if (validator is null)
    {
      return await next();
    }
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (validationResult.IsValid)
    {
      return await next();
    }

    return TryCreateResponseFromErrors(validationResult.Errors, out var response)
            ? response
            : throw new ValidationException(validationResult.Errors);
  }

  private static bool TryCreateResponseFromErrors(List<ValidationFailure> validationFailures, out TResponse response)
  {
    List<Error> errors = validationFailures.ConvertAll(x => Error.Validation(
            code: x.PropertyName,
            description: x.ErrorMessage));

    response = (TResponse?)typeof(TResponse)
        .GetMethod(
            name: nameof(ErrorOr<object>.From),
            bindingAttr: BindingFlags.Static | BindingFlags.Public,
            types: new[] { typeof(List<Error>) })?
        .Invoke(null, new[] { errors })!;

    return response is not null;
  }
}