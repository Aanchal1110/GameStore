
namespace WebApplication1.Models;

public class Games
{
    public int Id {get; set;}

    public required string Name {get; set;}

    public Genre? Genre{get; set;}

    public decimal price{get; set;}

    public DateOnly ReleaseDate{get;set;}
}
