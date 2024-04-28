using FluentResults;

namespace BuberDinner.Application.Services;
public interface IAuthenticationService
{
  Result<AuthenticationResult> Register(string firsName, string lastName, string email, string password);
  AuthenticationResult Login(string email, string password);
}
