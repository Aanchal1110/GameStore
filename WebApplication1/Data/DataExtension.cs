//The class that contains the logic for automatic migration of any new change in the app to the database

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public static class DataExtension
{

    public static void MigrateDb(this WebApplication app)
    {
        using var scope=app.Services.CreateScope();
        var dbContext=scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }
    public static void AddGameStoreDB(this WebApplicationBuilder builder)
    {
        var conString=builder.Configuration.GetConnectionString("GameStore");
        builder.Services.AddSqlite<GameStoreContext>(conString,
optionsAction:options =>options.UseSeeding((context, _) =>
{
    if (!context.Set<Genre>().Any())
    {
        context.Set<Genre>().AddRange(
            new Genre{name="Fighting"},
            new Genre{name="RPG"},
            new Genre{name="Platformer"},
            new Genre{name="Sports"}
        );
        context.SaveChanges();
    }
})

);
    }

}
