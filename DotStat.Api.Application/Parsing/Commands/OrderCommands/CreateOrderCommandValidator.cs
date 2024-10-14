using FluentValidation;

namespace DotStat.Api.Application.Parsing.Commands.OrderCommands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
  public CreateOrderCommandValidator()
  {
    RuleFor(x => x.Items.Count()).GreaterThan(0);
    RuleForEach(x => x.Items).SetValidator(new CreateOrderItemValidator());
  }
}