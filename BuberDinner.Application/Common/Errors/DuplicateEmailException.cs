using System.Net;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Application.Common.Errors;


public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already exists.";

}