using System.ComponentModel.DataAnnotations;
using Cash.BE.Helpers;

namespace Cash.BE.Request;

public class UserCreateRequest
{
    
    public string? UserName { get; set; } 
    public  string? Email { get; set; } 
    public  string? Password { get; set; } 
    public  int RolId { get; set; }
   
}