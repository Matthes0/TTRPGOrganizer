using System.ComponentModel.DataAnnotations;

namespace TTRPGOrganizer.shared.DTOs;

public record CreateCharacterDto(
    [Required][StringLength(50)] string Name
    );