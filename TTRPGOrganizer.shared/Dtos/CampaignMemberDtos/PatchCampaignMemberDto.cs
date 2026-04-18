using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.shared.DTOs;

public record PatchCampaignMemberDto(
    int? CampaignId,
    string? UserId,
    string? UserName,
    UserType? UserType,
    string? PersonalNotes
    );