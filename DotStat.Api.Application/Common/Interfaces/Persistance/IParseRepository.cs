using DotStat.Api.Domain.ComplexAggregate.ValueObjects;
using DotStat.Api.Domain.ParseAggregate;
using DotStat.Api.Domain.ParseAggregate.ValueObjects;

namespace DotStat.Api.Application.Common.Interfaces.Persistance;

public interface IParseRepository : IRepository<Parse>
{
  Parse? GetById(ParseId id);
  Task<Parse?> GetByIdAsync(ParseId id);
  ICollection<Parse> GetComplexParses(ComplexId complexId);
  Task<ICollection<Parse>> GetComplexParsesAsync(ComplexId complexId);
  bool Exist(ParseId id);
  Task<bool> ExistAsync(ParseId id);
}