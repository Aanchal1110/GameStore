namespace WebApplication1.Dtos;

public record GameDto(
    int Id,
    string name,
    string genre,
    decimal price,
    DateOnly ReleaseDate

);
