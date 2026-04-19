using Microsoft.Extensions.Logging;
using Cantask.Data;
using Cantask.Services;


namespace Cantask;

public static class MauiProgram
{
        public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddScoped<NodeService>();
        builder.Services.AddScoped<RelationshipService>();
        builder.Services.AddScoped<ProjectService>();
        builder.Services.AddScoped<DevService>();

    #if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
    #endif

        builder.Services.AddDbContext<AppDbContext>();

        var app = builder.Build();

        // Manejar excepciones en el inicializador de la base de datos
        try
        {
        using (var scope = app.Services.CreateScope())
{
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.EnsureCreated(); 

        DatabaseInitializer.Seed(context);
}
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al inicializar la base de datos: {ex.Message}");
        }

        return app;
    }
}