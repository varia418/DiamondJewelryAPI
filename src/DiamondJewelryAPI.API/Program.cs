using DiamondJewelryAPI.API;
using DiamondJewelryAPI.API.Common.Mapping;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers(options =>
    {
        options.InputFormatters.Insert(0, new TextPlainInputFormatter());
    });

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });

    builder.Services
        .AddPersistence(builder.Configuration)
        .AddAuth(builder.Configuration)
        .AddMappings();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

