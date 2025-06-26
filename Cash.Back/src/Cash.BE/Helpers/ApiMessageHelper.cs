namespace Cash.BE.Helpers;

public class ApiMessageHelper
{
    public static readonly Dictionary<StatusCode, string> Messages = new()
    {
        { StatusCode.Ok, "Request completed successfully." },
        { StatusCode.Created, "Resource created successfully." },
        { StatusCode.Accepted, "Request accepted for processing." },
        { StatusCode.NoContent, "No content to return." },
        { StatusCode.NotModified, "Resource not modified." },
        { StatusCode.BadRequest, "The request is invalid." },
        { StatusCode.Unauthorized, "Authentication is required." },
        { StatusCode.NotFound, "The requested resource was not found." },
        { StatusCode.InternalServerError, "An unexpected error occurred." }
    };   
}