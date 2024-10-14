using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Commands.RegisterCommand;

public class RegisterCommandHandler(IUserRepository userRepository) : IRequestHandler<RegisterCommand, ErrorOr<UserResult>>
{
  public async Task<ErrorOr<UserResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
  {
    if (await userRepository.ExistAsync(request.Email))
      return Errors.User.EmailAlreadyRegistered;

    var user = User.Create(
      request.FirstName,
      null,
      null,
      request.Email,
      request.Password
    );
    await userRepository.AddAsync(user);
    await userRepository.SaveChangesAsync();

    return new UserResult(user);
  }
}
