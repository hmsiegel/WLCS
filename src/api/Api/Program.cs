var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .InstallServices(
        builder.Configuration,
        typeof(IServiceInstaller).Assembly);
}

var app = builder.Build();
{
    app.RegisterPipelineCompnents(typeof(Program));
    app.Run();
}
