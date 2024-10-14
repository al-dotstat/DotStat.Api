using DotStat.Api.Application.Auth.Results;
using DotStat.Api.Application.Common.Interfaces.Persistance;
using DotStat.Api.Domain.Common.Errors;
using DotStat.Api.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace DotStat.Api.Application.Auth.Queries.UserQuery;

public class UserQueryHandler(IUserRepository userRepository) : IRequestHandler<UserQuery, ErrorOr<UserResult>>
{
  public async Task<ErrorOr<UserResult>> Handle(UserQuery request, CancellationToken cancellationToken)
  {
    if (await userRepository.GetByIdAsync(request.UserId) is not User user)
      return Errors.User.UnknownUser;

    return new UserResult(user);
  }
}
