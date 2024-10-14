using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Queries.UserQuery;

public record UserQuery(
  UserId UserId
) : IRequest<ErrorOr<UserResult>>;