using WebApplication1.Dtos;
using WebApplication1.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

var app = builder.Build();
app.MapGamesEndPoints();

app.Run();
