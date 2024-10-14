using FluentValidation;

namespace DotStat.Api.Application.Auth.Commands.RefreshCommand;

public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
{
  public RefreshCommandValidator()
  {
    RuleFor(x => x.RefreshToken).NotEmpty();
  }
}