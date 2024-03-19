LoggingUtility.Run(() =>
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services
    .InstallServicesFromAssemblies(
        builder.Configuration,
        App.AssemblyReference.Assembly,
        Authorization.AssemblyReference.Assembly,
        Persistence.AssemblyReference.Assembly);

    builder.Host.UseSerilogWihtConfiguration();

    var app = builder.Build();

    app
        .UseSwagger()
        .UseSwaggerUI()
        .UseCors(corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });

    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
});
