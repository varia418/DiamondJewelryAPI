using DiamondJewelryAPI.API;
using DiamondJewelryAPI.API.Common.Mapping;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers(options =>
    {
        options.InputFormatters.Insert(0, new TextPlainInputFormatter());
    });

    builder.Services
        .AddPersistence(builder.Configuration)
        .AddAuth(builder.Configuration)
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

