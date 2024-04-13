using Microsoft.Extensions.DependencyInjection;
using Sughd.Auto.Application.Interfaces.Repositories;
using Sughd.Auto.Infrastructure.Repositories;

namespace Sughd.Auto.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddScoped<ICarMarkaRepository, CarMarkaRepository>();
        services.AddScoped<ICarModelRepository, CarModelRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}