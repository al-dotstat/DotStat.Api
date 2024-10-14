using FluentValidation;

namespace DotStat.Api.Application.Parsing.Commands.OrderCommands;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItem>
{
  public CreateOrderItemValidator()
  {
    RuleFor(x => x).Must(x => x.IncludeCommercials || x.IncludeFlats || x.IncludeParkings || x.IncludeCommercials || x.IncludeStorages);
  }
}