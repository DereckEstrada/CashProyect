using System.Text;
using Cash.Exceptions.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Cash.API.Extensions;

public static class ServiceExtension
{
    public static async Task AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        
        services.AddSerilog();

        services.AddAuthentication(builder =>
        {
            builder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            builder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(builder =>
        {
            builder.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = configuration["Jwt:Issuer"] ?? throw new InvalidConfigurationException(MessageExceptions.InvalidIssuer),
                ValidateAudience = true,
                ValidAudience = configuration["Jwt:Audience"] ?? throw new InvalidConfigurationException(MessageExceptions.InvalidAudience),
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? throw new InvalidConfigurationException(MessageExceptions.InvalidKey))),
                ValidateLifetime = false
            };
        });
        services.AddAuthorization();
    }
}