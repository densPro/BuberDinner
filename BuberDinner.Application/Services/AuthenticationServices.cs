namespace BuberDinner.Application.Services;
public class AuthenticationServices : IAuthenticationService
{

  public AuthenticationResult Register(string firsName, string lastName, string email, string password)
  {
    // Check if user already exists
    // Create user (generate unique ID)
    //Create JWT Token
    return new AuthenticationResult(
      Guid.NewGuid(),
      firsName,
      lastName,
      email,
      "token"
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