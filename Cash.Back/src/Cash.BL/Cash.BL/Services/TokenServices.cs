using Cash.BE.Configuration;
using Microsoft.Extensions.Options;

namespace Cash.BL.Services;

public class TokenServices(IOptions<JwtOptions> jwtOptions)
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;
    
}