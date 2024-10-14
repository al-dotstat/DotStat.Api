using DotStat.Api.Domain.UserAggregate;

namespace DotStat.Api.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
  string GenerateToken(User user);
}