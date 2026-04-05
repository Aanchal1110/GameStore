//The class that contains the logic for automatic migration of any new change in the app to the database

using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public static class DataExtension
{

    public static void MigrateDb(this WebApplication app)
    {
        using var scope=app.Services.CreateScope();
        var dbContext=scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

}
