using System.ComponentModel.DataAnnotations;

namespace TTRPGOrganizer.shared.DTOs;

public record RpgSystemDetailsDto(
    int Id,
    string Name,
    string? ShortName,
    string? Description
    );