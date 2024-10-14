using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Application.Common.Interfaces.Authentication;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.ChangePassword;

public class ChangePasswordCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<ChangePasswordCommand, ErrorOr<AuthenticationResult>>
{
  public async Task<ErrorOr<AuthenticationResult>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
  {
    if (await userRepository.GetByIdAsync(request.UserId) is not User user)
      return Errors.User.UnknownUser;

    user.ChangePassword(request.Password);

    var refreshToken = RefreshToken.Create(null, null);
    user.AddRefreshToken(refreshToken);

    userRepository.Update(user);
    await userRepository.SaveChangesAsync();

    var token = jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(user, token, refreshToken.Id.Value);
  }
}
