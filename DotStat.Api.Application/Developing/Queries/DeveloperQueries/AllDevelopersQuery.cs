using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQueries;

public record AllDevelopersQuery() : IRequest<ErrorOr<DevelopersResult>>;