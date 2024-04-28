using FluentResults;

namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailError() : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "Email is already in use.";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
