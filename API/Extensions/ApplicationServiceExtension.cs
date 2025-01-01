using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
     IConfiguration configuration)
    {

        // Add services to the container.

        services.AddControllers();

        // link voi data => phan nay thuc ra chua hieu lam 
        services.AddDbContext<DataContext>(
            options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            }
        );

        // them CORS
        services.AddCors();

        // them service token 
        services.AddScoped<ITokenService, TokenService>();

        return services;

    }
}
