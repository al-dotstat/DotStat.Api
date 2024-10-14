using FluentValidation;

namespace DotStat.Api.Application.Auth.Commands.RevokeCommand;

public class RevokeCommandValidator : AbstractValidator<RevokeCommand>
{
  public RevokeCommandValidator()
  {
    RuleFor(x => x.RefreshToken).NotEmpty();
  }
}