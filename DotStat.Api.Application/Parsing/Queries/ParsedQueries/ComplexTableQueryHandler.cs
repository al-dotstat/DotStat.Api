using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Application.Parsing.Export;
using DotStat.Api.Application.Parsing.Results;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.ComplexAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.ParsedQueries;

public class ComplexTableQueryHandler(
  IComplexRepository complexRepository,
  IFlatRepository flatRepository,
  IParkingRepository parkingRepository,
  IStorageRepository storageRepository,
  ICommercialRepository commercialRepository
) : IRequestHandler<ComplexTableQuery, ErrorOr<TableResult>>
{
  public async Task<ErrorOr<TableResult>> Handle(ComplexTableQuery request, CancellationToken cancellationToken)
  {
    if (await complexRepository.GetByIdAsync(request.ComplexId) is not Complex complex)
      return Errors.Complex.UnknownComplex;

    var flats = request.IncludeFlats ? await flatRepository.GetComplexFlatsAsync(request.ComplexId) : [];
    var flatsTable = request.IncludeFlats ? TableConverter.FlatsToArray(flats, complex.NameRu) : null;

    var parkings = request.IncludeParkings ? await parkingRepository.GetComplexParkingsAsync(request.ComplexId) : [];
    var parkingsTable = request.IncludeParkings ? TableConverter.ParkingsToArray(parkings, complex.NameRu) : null;

    var storages = request.IncludeStorages ? await storageRepository.GetComplexStoragesAsync(request.ComplexId) : [];
    var storagesTable = request.IncludeStorages ? TableConverter.StoragesToArray(storages, complex.NameRu) : null;

    var commercials = request.IncludeCommercials ? await commercialRepository.GetComplexCommercialsAsync(request.ComplexId) : [];
    var commercialsTable = request.IncludeCommercials ? TableConverter.CommercialsToArray(commercials, complex.NameRu) : null;

    return new TableResult(flatsTable, parkingsTable, storagesTable, commercialsTable);
  }
}