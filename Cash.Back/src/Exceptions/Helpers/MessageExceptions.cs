namespace Cash.Exceptions.Helpers;

public class MessageExceptions
{
    public const string InvalidIssuer = "Fail configuration Issuer";
    public const string InvalidAudience = "Fail configuration Audience";
    public const string InvalidKey = "Fail configuration Key";
    
    public const string PaginationWithOutOrder = "Can't apply pagination without order";
    public const string FieldNotFound = "Field not found";
    public const string FieldNotAllowed = "Field is not allowed";
    public const string NotFound = "Element not found";
}