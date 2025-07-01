using System.Security.Authentication;
using System.Security.Claims;
using Cash.BL.Attributes;
using Cash.BL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Cash.BL.Services;
[Service]
public class HttpContextServices(IHttpContextAccessor? httpContextAccessor): IHttpContextServices
{
    private readonly IHttpContextAccessor? _httpContextAccessor = httpContextAccessor;

    public ClaimsPrincipal GetClaims()
    {
        var claims = _httpContextAccessor?.HttpContext.User;
        
        if (claims is null) throw new AuthenticationException();
        
        return claims;
    }
}