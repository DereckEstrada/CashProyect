using System.ComponentModel.DataAnnotations;

namespace Cash.BE.Configuration;

public class JwtOptions
{
    [Required]
    public required string SecreteKey {get;set;}
    [Required]
    public required string Audience {get;set;}
    [Required]
    public required string Issuer {get;set;}
    [Required]
    public required int Expiration {get;set;}    
}