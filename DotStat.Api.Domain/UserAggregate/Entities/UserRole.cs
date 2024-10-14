using DotStat.Api.Domain.Common.Models;
using DotStat.Api.Domain.UserAggregate.ValueObjects;

namespace DotStat.Api.Domain.UserAggregate.Entities;

public sealed class UserRole : Entity<UserRoleId>
{
  public string Name { get; private set; }
  public string NormalizedName { get; private set; }

  private UserRole(string name)
  {
    Name = name;
    NormalizedName = name.ToUpper();
  }

  public static UserRole Create(string name)
  {
    return new(name);
  }

#pragma warning disable CS8618
  private UserRole()
  {
  }
#pragma warning restore CS8618
}