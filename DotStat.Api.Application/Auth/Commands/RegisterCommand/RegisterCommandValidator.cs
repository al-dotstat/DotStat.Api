using FluentValidation;

namespace DotStat.Api.Application.Auth.Commands.RegisterCommand;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
  public RegisterCommandValidator()
  {
    RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
    RuleFor(x => x.Email).EmailAddress();
    RuleFor(x => x.Password).NotEmpty();
  }
}