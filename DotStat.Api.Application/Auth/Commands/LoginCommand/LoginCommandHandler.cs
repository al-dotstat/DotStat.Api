using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Application.Common.Interfaces.Authentication;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DotStat.Api.Application.Auth.Commands.LoginCommand;

public class LoginCommandHandler(
  IUserRepository userRepository,
  IJwtTokenGenerator jwtTokenGenerator
) : IRequestHandler<LoginCommand, ErrorOr<AuthenticationResult>>
{
  public async Task<ErrorOr<AuthenticationResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
  {
    if (await userRepository.GetByEmailAsync(request.Email) is not User user)
      return Errors.User.UnknownUser;

    var verifiedHash = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password);

    if (verifiedHash == PasswordVerificationResult.Failed)
      return Errors.User.InvalidCredentials;

    var token = jwtTokenGenerator.GenerateToken(user);
    var refreshToken = RefreshToken.Create(null, null);
    user.AddRefreshToken(refreshToken);

    userRepository.Update(user);
    await userRepository.SaveChangesAsync();

    return new AuthenticationResult(user, token, refreshToken.Id.Value);
  }
}
