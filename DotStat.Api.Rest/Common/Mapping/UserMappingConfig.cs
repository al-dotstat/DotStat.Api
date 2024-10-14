using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Contracts.User;
using DotStat.Api.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace DotStat.Api.Rest.Common.Mapping;

public class UserMappingConfig : IRegister
{
  public void Register(TypeAdapterConfig config)
  {
    config.NewConfig<UserId, int>()
      .MapWith(src => src.Value);

    config.NewConfig<UserResult, UserResponse>()
      .Map(dest => dest, src => src.User);

    config.NewConfig<AuthenticationResult, AuthenticationResponse>()
      .Map(dest => dest.User, src => src.User)
      .Map(dest => dest.Tokens, src => new RefreshResponse(src.Token, src.RefreshToken));

    config.NewConfig<TokensResult, RefreshResponse>();
  }
}
