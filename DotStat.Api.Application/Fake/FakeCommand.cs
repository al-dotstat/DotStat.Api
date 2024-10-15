using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Fake;

public record FakeCommand() : IRequest<ErrorOr<bool>>;