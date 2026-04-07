namespace WebApplication1.Dtos;

public record GameDetailsDto(
    int Id,
    string name,
    int genreId,
    decimal price,
    DateOnly ReleaseDate

);
