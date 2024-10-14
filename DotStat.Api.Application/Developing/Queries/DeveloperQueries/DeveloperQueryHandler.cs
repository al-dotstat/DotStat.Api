using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.DeveloperAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQueries;

public class DeveloperQueryHandler(IDeveloperRepository developerRepository) : IRequestHandler<DeveloperQuery, ErrorOr<DeveloperResult>>
{
  public async Task<ErrorOr<DeveloperResult>> Handle(DeveloperQuery request, CancellationToken cancellationToken)
  {
    if (await developerRepository.GetByIdAsync(request.Id) is not Developer developer)
      return Errors.Developer.UnknownDeveloper;

    return new DeveloperResult(developer);
  }
}
