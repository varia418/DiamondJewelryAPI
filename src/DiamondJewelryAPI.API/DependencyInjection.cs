using DiamondJewelryAPI.API.Common.Attributes;
using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Repositories;
using DiamondJewelryAPI.API.Services;

using Microsoft.Extensions.Options;

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

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

        return services;
    }
}