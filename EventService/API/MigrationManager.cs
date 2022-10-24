using Microsoft.EntityFrameworkCore;

namespace EventService.Infrastructure;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<EventsContext>())
            {
                try
                {
                    appContext.Database.Migrate();
                }
                catch (Exception)
                {
                    //TODO: handle
                    throw;
                }
            }
        }
        return webApp;
    }
}
