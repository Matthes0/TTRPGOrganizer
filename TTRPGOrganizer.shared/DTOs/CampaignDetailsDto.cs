using System.ComponentModel.DataAnnotations;
using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.shared.DTOs;

public record CampaignDetailsDto(
    int Id,
    string Name,
    int? RpgSystemId,
    UserType UserType,
    string? Description,
    string? PersonalNotes
    );