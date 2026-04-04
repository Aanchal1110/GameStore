using WebApplication1.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games=[new(1, "Street Fighter","fighting",12.45m,new DateOnly(2001, 11, 5)),
new(2,"Free fire","Fighting", 24.45m, new DateOnly(2005, 4, 3)),
new(3,"Temple run","Racing",45.23m,new DateOnly(2002, 3,5))];

app.MapGet("/games", () => games);

//GET games/id
app.MapGet("/games/{id}",(int id) => games.Find(game =>game.Id==id) );




app.Run();
