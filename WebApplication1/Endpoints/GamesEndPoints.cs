using System;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Endpoints;

public static class GamesEndPoints
{
    static List<GameSummaryDto> games = [new(1, "Street Fighter","fighting",12.45m,new DateOnly(2001, 11, 5)),
new(2,"Free fire","Fighting", 24.45m, new DateOnly(2005, 4, 3)),
new(3,"Temple run","Racing",45.23m,new DateOnly(2002, 3,5))];

    public static void MapGamesEndPoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");

        group.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre).Select
        (game => new GameSummaryDto(
            game.Id,
            game.Name,
            game.Genre!.name,
            game.price,
            game.ReleaseDate
        )).AsNoTracking().ToListAsync());


        const string GetGameEndpointName = "GetGame";

        //GET games/id
        group.
        MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            var game = await dbContext.Games.FindAsync(id);


            return game is null ? Results.NotFound() : Results.Ok(new GameDetailsDto(
     game.Id,
     game.Name,
     game.genreId,
     game.price,
     game.ReleaseDate
    ));
        }
             ).
        WithName(GetGameEndpointName);

        //POST games
        group.MapPost("/", async (CreateDto newGame, GameStoreContext dbContext) =>
        {
            Games game = new()
            {
                Name = newGame.name,
                genreId = newGame.genreId,
                price = newGame.price,
                ReleaseDate = newGame.releaseDate
            };
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            GameDetailsDto gameDetailsDto = new(
                game.Id,
                game.Name,
                game.genreId,
                game.price,
                game.ReleaseDate
            );

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameDetailsDto.Id }, gameDetailsDto);
        });


        //PUT /games/{id}
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
         {
             var existingGame = await dbContext.Games.FindAsync(id);

             if (existingGame is null)
             {
                 return Results.NotFound();
             }

             existingGame.Name = updatedGame.name;
             existingGame.genreId = updatedGame.genreId;
             existingGame.price = updatedGame.price;
             existingGame.ReleaseDate = existingGame.ReleaseDate;

             await dbContext.SaveChangesAsync();
             return Results.NoContent();
         });

        //DELETE /games/{id}
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();

            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });
    }
}
