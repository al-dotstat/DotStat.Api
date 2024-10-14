using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate;
using DotStat.Api.Domain.UserAggregate.Entities;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.RevokeCommand;

public class RevokeCommandHandler(IUserRepository userRepository) : IRequestHandler<RevokeCommand, ErrorOr<bool>>
{
  public async Task<ErrorOr<bool>> Handle(RevokeCommand request, CancellationToken cancellationToken)
  {
    if (await userRepository.GetByIdAsync(request.UserId) is not User user)
      return Errors.User.UnknownUser;

    if (user.RefreshTokens.FirstOrDefault(rt => rt.Id.Value == request.RefreshToken) is not RefreshToken refreshToken)
      return Errors.User.UnknownRefreshToken;

    user.RemoveRefreshToken(refreshToken);
    userRepository.Update(user);
    await userRepository.SaveChangesAsync();

    return true;
  }
}
