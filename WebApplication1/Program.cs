using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();




var conString="Data Source=GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(conString);
var app = builder.Build();
app.MapGamesEndPoints();
app.MigrateDb();
app.Run();
