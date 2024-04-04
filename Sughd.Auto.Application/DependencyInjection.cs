using Microsoft.Extensions.DependencyInjection;
using Sughd.Auto.Application.Automapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Interfaces.Auth;
using Sughd.Auto.Application.Services;
using Sughd.Auto.Application.Services.Auth;

namespace Sughd.Auto.Application;

public static class DependencyInjection
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<ICarMarkaService, CarMarkaService>();
        services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IRoleService, RoleService>(); 
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<ICarModelService, CarModelService>();
    }
}