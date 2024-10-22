using FluentValidation;

namespace DotStat.Api.Application.Parsing.Queries.ParsedQueries;

public class ComplexExportQueryValidator : AbstractValidator<ComplexExportQuery>
{
  public ComplexExportQueryValidator()
  {
    RuleFor(x => x)
      .Must(x => x.IncludeCommercials || x.IncludeFlats || x.IncludeParkings || x.IncludeCommercials || x.IncludeStorages)
      .WithMessage("Выберите хотя-бы один тип помещения");
  }
}