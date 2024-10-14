using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.DeveloperQueries;

public class AllDevelopersQueryHandler(IDeveloperRepository developerRepository) : IRequestHandler<AllDevelopersQuery, ErrorOr<DevelopersResult>>
{
  public async Task<ErrorOr<DevelopersResult>> Handle(AllDevelopersQuery request, CancellationToken cancellationToken)
  {
    var developers = await developerRepository.GetAllAsync();

    return new DevelopersResult(developers);
  }
}
