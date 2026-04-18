using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.shared.DTOs;

public record CreateCampaignMemberDto(
    string UserId,
    UserType UserType
    );