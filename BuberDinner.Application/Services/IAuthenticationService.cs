using BuberDinner.Application.Common.Errors;
using OneOf;

namespace BuberDinner.Application.Services;
public interface IAuthenticationService
{
  OneOf<AuthenticationResult, IError> Register(string firsName, string lastName, string email, string password);
  AuthenticationResult Login(string email, string password);
}
