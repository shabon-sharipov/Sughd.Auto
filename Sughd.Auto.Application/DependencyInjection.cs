using Microsoft.Extensions.DependencyInjection;
using Sughd.Auto.Application.Automapper;
using Sughd.Auto.Application.Interfaces;
using Sughd.Auto.Application.Services;

namespace Sughd.Auto.Application;

public static class DependencyInjection
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<ICarModelService, CarModelService>();
        services.AddScoped<ICarMarkaService, CarMarkaService>();
        services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);
    }
}