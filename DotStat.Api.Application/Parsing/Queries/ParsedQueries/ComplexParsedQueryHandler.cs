using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.ParsedQueries;

public class ComplexParsedQueryHandler(IComplexRepository complexRepository, IParseRepository parseRepository) : IRequestHandler<ComplexParsedQuery, ErrorOr<ParsingsResult>>
{
  public async Task<ErrorOr<ParsingsResult>> Handle(ComplexParsedQuery request, CancellationToken cancellationToken)
  {
    if (!await complexRepository.ExistAsync(request.ComplexId))
      return Errors.Complex.UnknownComplex;

    var parses = await parseRepository.GetComplexParsesAsync(request.ComplexId);
    var results = parses.Select(p => new ParsingResult(
      p.Id,
      p.Date,
      p.ComplexId,
      p.AreFlatsParsed,
      p.AreParkingsParsed,
      p.AreStoragesParsed,
      p.AreCommercialsParsed,
      p.CreatedDateTime,
      p.UpdatedDateTime));
    return new ParsingsResult(results);
  }
}
