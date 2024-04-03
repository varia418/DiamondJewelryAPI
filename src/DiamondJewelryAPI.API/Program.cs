var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
}


var app = builder.Build();
{
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

