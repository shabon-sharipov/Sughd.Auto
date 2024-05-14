using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sughd.Auto.Application.AuthServices;
using Sughd.Auto.Application.Constants;
using Sughd.Auto.Application.Interfaces.Auth.AuthRepository;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Domain.AuthModel;
using Sughd.Auto.Infrastructure.DataBase;

namespace Sughd.Auto.API;

public static class DependencyInjection
{
    public static void AddApiLayer(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });
            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.AddCors();
    }

    public static void AddDbContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<EFContext>(options =>
        {
            builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseLazyLoadingProxies();
        });
        
        services.AddDbContext<EFContextV2>(options =>
        {
            builder.Configuration.GetConnectionString("DefaultConnectionV2");
            options.UseLazyLoadingProxies();
        });
    }

    public static void AddAuthToken(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!))
                };
            });
        services.AddAuthorization();
    }
}