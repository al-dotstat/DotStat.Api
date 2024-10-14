using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Application.Common.Interfaces.Authentication;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.RefreshCommand;

public class RefreshCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RefreshCommand, ErrorOr<TokensResult>>
{
  public async Task<ErrorOr<TokensResult>> Handle(RefreshCommand request, CancellationToken cancellationToken)
  {
    if (await userRepository.GetByRefreshTokenAsync(request.RefreshToken) is not User user)
      return Errors.User.UnknownRefreshToken;

    var oldRefreshToken = user.RefreshTokens.First(rt => rt.Id.Value == request.RefreshToken);
    user.RemoveRefreshToken(oldRefreshToken);

    var newRefreshToken = RefreshToken.Create(null, null);
    user.AddRefreshToken(newRefreshToken);

    userRepository.Update(user);
    await userRepository.SaveChangesAsync();

    var token = jwtTokenGenerator.GenerateToken(user);
    return new TokensResult(token, newRefreshToken.Id.Value);
  }
}
