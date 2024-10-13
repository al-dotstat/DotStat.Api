using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.AllDevelopersQuery;

public record AllDevelopersQuery() : IRequest<ErrorOr<DevelopersResult>>;