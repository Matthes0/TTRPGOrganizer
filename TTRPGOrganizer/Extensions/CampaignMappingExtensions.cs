using TTRPGOrganizer.Models;
using TTRPGOrganizer.shared.DTOs;

namespace TTRPGOrganizer.Extensions;

public static class CampaignMappingExtensions
{
    public static CampaignDetailsDto ToDetailsDto(this Campaign campaign, string? userName = null)
    {
        return new CampaignDetailsDto(
            campaign.Id,
            campaign.Name,
            campaign.RpgSystemId,
            campaign.Description,
            campaign.SharedNotes,
            campaign.Members.Select(member => member.ToDetailsDto(userName)).ToList());
    }
}