using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Developing.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.ComplexAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Developing.Queries.ComplexQueries;

public class ComplexQueryHandler(IComplexRepository complexRepository) : IRequestHandler<ComplexQuery, ErrorOr<ComplexResult>>
{
  public async Task<ErrorOr<ComplexResult>> Handle(ComplexQuery request, CancellationToken cancellationToken)
  {
    if (await complexRepository.GetByIdAsync(request.Id) is not Complex complex)
      return Errors.Complex.UnknownComplex;

    return new ComplexResult(complex);
  }
}
