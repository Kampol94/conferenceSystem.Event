using EventService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EventService.API;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (IServiceScope scope = webApp.Services.CreateScope())
        {
            using EventsContext appContext = scope.ServiceProvider.GetRequiredService<EventsContext>();
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
        return webApp;
    }
}
