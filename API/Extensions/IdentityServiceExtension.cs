using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class IdentityServiceExtension
{
    public static IServiceCollection AddIdentityService(this IServiceCollection services,
     IConfiguration configuration)
    {

        // them service authentic
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                            {
                                var tokenKey = configuration["TokenKey"] ?? throw Exception("TokenKey not found! ");
                                options.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                                    ValidateIssuer = false,
                                    ValidateAudience = false,
                                };
                            });
        return services;

        static Exception Exception(string v)
        {
            throw new NotImplementedException();
        };
    }
}
