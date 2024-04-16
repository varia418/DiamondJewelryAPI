using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Repositories;
using DiamondJewelryAPI.API.Interfaces.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Repositories;
using DiamondJewelryAPI.API.Services;

using Microsoft.Extensions.Options;

namespace DiamondJewelryAPI.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DiamondJewelryDBSettings>(
            configuration.GetSection("DiamondJewelryDB"));

        services.AddSingleton<IDiamondJewelryDBSettings>(sp =>
                    sp.GetRequiredService<IOptions<DiamondJewelryDBSettings>>().Value);

        services.AddScoped<IMongoContext, MongoContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}