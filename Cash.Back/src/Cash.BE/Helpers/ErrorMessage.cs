namespace Cash.BE.Helpers;

public class ErrorMessage
{
    
    public const string RequiredGeneric = "Field is required";
    public const string RequiredUsename = "Usename is required";
    public const string RequiredEmail = "Email is required";
    public const string RequiredPassword = "Password is required";
    public const string RequiredRol = "Rol is required";
    public const string RequiredId = "Id is required";
    public const string RequiredStatus = "Status is required";
    public const string RequiredName = "Name is required";
    public const string RequiredLastName = "LastName is required";
    public const string RequiredIdentification = "Identification is required";
    public const string RequiredPhone = "Phone is required";
    public const string RequiredMethod = "Method is required";
    public const string RequiredFieldName = "FieldName is required";
    public const string RequiredFieldValue = "FieldValue is required";
    
    
    
    public const string NotFormatEmail = "Format invalid email";
    
    public const string ExpressionAddressAnReferences = "The text must be between 20 and 100 characters";
    public const string ExpressionPassword = "The password must be 8-30 characters, with uppercase, lowercase, numbers and symbols";
    public const string ExpressionUserName = "The username must be between 8 and 20 characters long, contain only letters and at least one number. Symbols are not allowed.";
    public const string ExpressionAllLetters = "This field only allows letters. Numbers, spaces, and special characters are not allowed";
    public const string ExpressionIdentification = "The identification must be between 10 and 13 digits and contain only numbers";
    public const string ExpressionPhone = "The number must start with 09 and have exactly 10 digits.";
    
    
    
    
    public const string NoIdentificated = "Anonimo";
    
    public const string FailedOperation = "Operation failed";   
}