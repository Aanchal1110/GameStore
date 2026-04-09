namespace WebApplication1.Dtos;

public record GameSummaryDto(
    int Id,
    string name,
    string genre,
    decimal price,
    DateOnly ReleaseDate

);
