using System.ComponentModel.DataAnnotations;

namespace TTRPGOrganizer.shared.DTOs;

public record CreateCharacterDTO(
    [Required][StringLength(50)] string Name
    );