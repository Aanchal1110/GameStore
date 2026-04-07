using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record CreateDto(
    [Required][StringLength(50)] string name,
    [Range(1,50)]int genreId,
    [Range(1,100)]decimal price,
    DateOnly releaseDate
);
