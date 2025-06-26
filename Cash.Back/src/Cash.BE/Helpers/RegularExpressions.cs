namespace Cash.BE.Helpers;

public class RegularExpressions
{
    public const string Password =  @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,30}$";
    public const string UserName = @"^(?=.*\d)[a-zA-Z\d]{8,20}$";
    public const string AllLetters = @"^[a-zA-Z\d]$";
    public const string Identification =  @"^\d{10,13}$";
    public const string AddressAnReferences =  @"^.{20,100}$";
    public const string Phone =  @"^09\d{8,}$";
    
}