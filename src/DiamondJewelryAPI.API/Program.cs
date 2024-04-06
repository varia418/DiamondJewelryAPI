using DiamondJewelryAPI.API.Models;
using DiamondJewelryAPI.API.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.Configure<DiamondJewelryDBSettings>(builder.Configuration.GetSection("DiamondJewelryDB"));
    builder.Services.AddSingleton<MongoDBService>();
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

