using System;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Endpoints;

public static class GamesEndPoints
{
    static List<GameDto> games=[new(1, "Street Fighter","fighting",12.45m,new DateOnly(2001, 11, 5)),
new(2,"Free fire","Fighting", 24.45m, new DateOnly(2005, 4, 3)),
new(3,"Temple run","Racing",45.23m,new DateOnly(2002, 3,5))];

    public static void MapGamesEndPoints(this WebApplication app)
    {
        var group=app.MapGroup("/games");

        group.MapGet("/", () => games);

const string GetGameEndpointName = "GetGame";

//GET games/id
group.
MapGet("/{id}",(int id) => {
   var game= games.Find(game =>game.Id==id);
   
   return game is null? Results.NotFound():Results.Ok(game);
   }
     ).
WithName(GetGameEndpointName);

//POST games
group.MapPost("/",(CreateDto newGame, GameStoreContext dbContext) =>
{
    Games game = new()
    {
        Name=newGame.name, 
        genreId = newGame.genreId,
        price=newGame.price,
        ReleaseDate=newGame.releaseDate
    };
    dbContext.Games.Add(game);
    dbContext.Sav
    return Results.CreatedAtRoute(GetGameEndpointName, new {id=game.Id},game);
});


//PUT /games/{id}
group.MapPut("/{id}",(int id, UpdateGameDto UpdatedGameDto) =>
{
    var index=games.FindIndex(game=>game.Id==id);

    if (index == -1)
    {
        return Results.NotFound();
    }
    games[index]=new GameDto(
        id,
        UpdatedGameDto.name,
        UpdatedGameDto.genre,
        UpdatedGameDto.price,
        UpdatedGameDto.releaseDate
    );
    return Results.NoContent();
});

//DELETE /games/{id}
group.MapDelete("/{id}",(int id)=>
{
    games.RemoveAll(game=>game.Id==id);
    return Results.NoContent();
});
    }
}
