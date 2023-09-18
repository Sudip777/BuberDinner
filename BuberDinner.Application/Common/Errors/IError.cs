using System.Net;

namespace BuberDinner.Application.Commonn.Errors;

public interface IError
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }

}