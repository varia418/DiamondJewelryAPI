using DiamondJewelryAPI.API.Interfaces.Persistence;
using DiamondJewelryAPI.API.Interfaces.Persistence.Services;
using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Repositories;
using DiamondJewelryAPI.API.Services;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services.Configure<DiamondJewelryDBSettings>(
        builder.Configuration.GetSection("DiamondJewelryDB"));

    builder.Services.AddScoped<IMongoContext, MongoContext>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IProductService, ProductService>();
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

