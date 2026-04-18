using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.shared.DTOs;

public record CampaignMemberDetailsDto(
    int Id,
    int CampaignId,
    string UserId,
    string UserName,
    UserType UserType,
    string? PersonalNotes
);