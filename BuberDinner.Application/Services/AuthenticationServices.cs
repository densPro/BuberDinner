using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services;
public class AuthenticationServices : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationServices(IJwtTokenGenerator jwtTokenGenerator)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public AuthenticationResult Register(string firsName, string lastName, string email, string password)
  {
    // Check if user already exists
    // Create user (generate unique ID)
    //Create JWT Token
    var userId = Guid.NewGuid();
    var token = _jwtTokenGenerator.GenerateToken(userId, firsName, lastName);
    return new AuthenticationResult(
      userId,
      firsName,
      lastName,
      email,
      token
    );
  }

  public AuthenticationResult Login(string email, string password)
  {
    return new AuthenticationResult(
      Guid.NewGuid(),
      "firsName",
      "lastName",
      email,
      "token"
    );
  }
}