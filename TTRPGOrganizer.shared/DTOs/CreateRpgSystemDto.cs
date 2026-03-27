using System.ComponentModel.DataAnnotations;

namespace TTRPGOrganizer.shared.DTOs;

public record CreateRpgSystemDto(
    [Required] [StringLength(50)] string Name,
    string? ShortName,
    string? Description
);
