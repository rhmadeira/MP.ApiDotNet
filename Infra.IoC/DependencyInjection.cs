using App.Mappings;
using App.Services;
using App.Services.Interfaces;
using Domain.Repositories;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC;

public static class DependencyInjection
{

    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(DomainToDtoMapping));
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}
