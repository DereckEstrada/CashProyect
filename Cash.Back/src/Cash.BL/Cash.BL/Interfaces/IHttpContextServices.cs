using System.Security.Claims;

namespace Cash.BL.Interfaces;

public interface IHttpContextServices
{
    ClaimsPrincipal? GetClaims();
}