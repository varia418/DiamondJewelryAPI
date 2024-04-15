using DiamondJewelryAPI.API;
using DiamondJewelryAPI.API.Common.Mapping;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();

    builder.Services
        .AddPersistence(builder.Configuration)
        .AddMappings();
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

