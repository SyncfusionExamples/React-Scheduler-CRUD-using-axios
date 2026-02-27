using Microsoft.EntityFrameworkCore;

namespace SchedulerApi.Data;

public static class DbInitializer
{
    public static void Initialize(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // Automatically applies migrations on startup
        context.Database.Migrate();
    }
}