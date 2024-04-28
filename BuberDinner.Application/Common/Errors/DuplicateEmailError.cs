using System.Net;

namespace BuberDinner.Application.Common.Errors;

public record struct DuplicateEmailError() : IError
{
    public HttpStatusCode StatusCode { get ;} = HttpStatusCode.Conflict;
    public string ErrorMessage { get ; } = "Email already exists";
}
