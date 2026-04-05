using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Endpoints;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.AddGameStoreDB();

var app = builder.Build();
app.MapGamesEndPoints();
app.MigrateDb();
app.Run();
