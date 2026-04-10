using TTRPGOrganizer.Models;
using TTRPGOrganizer.shared.DTOs;

namespace TTRPGOrganizer.Extensions;

public static class CampaignMemberMappingExtensions
{
    public static CampaignMemberDetailsDto ToDetailsDto(this CampaignMember member, string? userName = null)
    {
        return new CampaignMemberDetailsDto(
            member.Id,
            member.CampaignId,
            member.UserId,
            member.User?.UserName ?? userName ?? "Unknown",
            member.UserType,
            member.PersonalNotes
        );

    }}