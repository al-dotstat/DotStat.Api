using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Commands.OrderCommands;

public record CreateOrderItem(
  ComplexId ComplexId,
  bool IncludeFlats,
  bool IncludeParkings,
  bool IncludeStorages,
  bool IncludeCommercials
);

public record CreateOrderCommand(
  UserId UserId,
  IEnumerable<CreateOrderItem> Items
) : IRequest<ErrorOr<OrderResult>>;