
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;

namespace WebApplication1.Endpoints;

public static class GenreEndPoint
{
    public static void MapGenreEndPoints(this WebApplication app)
    {
        var group =app.MapGroup("/genres");
        //Get/genre

         group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Genres
                .Select(genre => new GenreDto(
                    genre.Id,
                    genre.Name   // ✅ correct mapping
                ))
                .AsNoTracking() // ✅ method call
                .ToListAsync()
        );
    }

}
