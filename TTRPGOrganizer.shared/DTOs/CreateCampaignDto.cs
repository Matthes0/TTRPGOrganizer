using System.ComponentModel.DataAnnotations;
using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.shared.DTOs;

public record CreateCampaignDto(
    [Required][StringLength(50)] string Name,
    int? RpgSystemId,
    UserType UserType,
    string? Description
    );