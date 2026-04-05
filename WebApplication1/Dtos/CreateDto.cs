using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record CreateDto(
    [Required] string name,
    string genre,
    decimal price,
    DateOnly releaseDate
);
