using DiamondJewelryAPI.API;
using DiamondJewelryAPI.API.Common.Mapping;

using Microsoft.AspNetCore.HttpOverrides;

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
    app.UseExceptionHandler("/api/v2/error");
    if (!app.Environment.IsDevelopment())
    {
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });
        app.UseHttpsRedirection();
    }
    app.UseCors();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

