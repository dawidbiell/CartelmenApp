using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Cartelmen.Application.Errors;

public class ApiException(HttpStatusCode statusCode, string message, string? details)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string? Message { get; } = message;
    public string? Details { get; } = details;
}