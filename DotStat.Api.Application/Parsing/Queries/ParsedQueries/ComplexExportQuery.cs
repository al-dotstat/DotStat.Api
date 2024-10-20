using DotStat.Api.Application.Common.Results;
using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Parsing.Queries.ParsedQueries;

public record ComplexExportQuery(
  ComplexId ComplexId,
  bool IncludeFlats,
  bool IncludeParkings,
  bool IncludeStorages,
  bool IncludeCommercials
) : IRequest<ErrorOr<FileResult>>;