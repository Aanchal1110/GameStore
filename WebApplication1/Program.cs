using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndPoints();

var conString="Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(conString);

app.Run();
