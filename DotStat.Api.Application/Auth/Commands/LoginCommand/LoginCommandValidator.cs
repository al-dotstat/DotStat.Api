using FluentValidation;

namespace DotStat.Api.Application.Auth.Commands.LoginCommand;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
  public LoginCommandValidator()
  {
    RuleFor(x => x.Email).EmailAddress();
    RuleFor(x => x.Password).NotEmpty();
  }
}