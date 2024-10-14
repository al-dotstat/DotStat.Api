using DotStat.Api.Application.Auth.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.RefreshCommand;

public record RefreshCommand(
  string RefreshToken
) : IRequest<ErrorOr<TokensResult>>;