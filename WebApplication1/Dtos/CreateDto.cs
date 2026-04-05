using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public record CreateDto(
    [Required][StringLength(50)] string name,
    [Required][StringLength(50)]string genre,
    [Range(1,100)]decimal price,
    DateOnly releaseDate
);
