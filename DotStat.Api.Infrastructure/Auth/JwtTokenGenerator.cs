using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotStat.Api.Application.Common.Interfaces.Authentication;
using DotStat.Api.Domain.UserAggregate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DotStat.Api.Infrastructure.Auth;

public class JwtTokenGenerator(IOptions<JwtSettings> jwtSettings) : IJwtTokenGenerator
{
  private readonly JwtSettings _jwtSettings = jwtSettings.Value;

  public string GenerateToken(User user)
  {
    var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim>
    {
      new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
      new(JwtRegisteredClaimNames.GivenName, user.FirstName),
      new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
      new(JwtRegisteredClaimNames.Email, user.Email),
      new(JwtRegisteredClaimNames.UniqueName, user.Email),
    };

    if (user.LastName is not null)
      claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName));

    foreach (var claim in user.Claims)
      claims.Add(new Claim(claim.Type, claim.Value));

    var securityToken = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
      claims: claims,
      signingCredentials: signingCredentials);

    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}
