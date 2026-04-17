using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TTRPGOrganizer.Data;
using TTRPGOrganizer.Extensions;
using TTRPGOrganizer.Models;
using TTRPGOrganizer.shared.DTOs;

namespace TTRPGOrganizer.Endpoints;

public static class CampaignMembersEndpoints
{
    private const string GetCampaignMemberEndpointName = "GetCampaignMember";

    public static void MapCampaignMembersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/campaigns/{campaignId:int}/members");
        // GET /campaigns/{campaignId}/members/{id}
        group.MapGet("/{id:int}", async Task<Results<NotFound, Ok<CampaignMemberDetailsDto>>> (int campaignId, int id, OrganizerContext db) =>
        {
            var campaignMember = await db.CampaignMembers.Include(campaignMember => campaignMember.User).FirstOrDefaultAsync(campaignMember => campaignMember.Id == id && campaignMember.CampaignId == campaignId);
            if (campaignMember is null) return TypedResults.NotFound();
            return TypedResults.Ok(campaignMember.ToDetailsDto());
        }).WithName(GetCampaignMemberEndpointName);
        // POST /campaigns/{campaignId}/members/
        group.MapPost("/", async Task<Results<NotFound, BadRequest<string>, CreatedAtRoute<CampaignMemberDetailsDto>>> (int campaignId, CreateCampaignMemberDto newCampaignMember, OrganizerContext db, ClaimsPrincipal user) =>
            {
                var campaign = await db.Campaigns.Include(campaign => campaign.Members).FirstOrDefaultAsync(campaign => campaign.Id == campaignId);
                if (campaign is null) return TypedResults.NotFound();
                if (campaign.Members.Any(member => member.UserId == newCampaignMember.UserId))
                {
                    return TypedResults.BadRequest("User is already a member of this campaign.");
                }

                var campaignMember = new CampaignMember()
                {
                    CampaignId = campaignId,
                    UserType = newCampaignMember.UserType,
                    UserId = newCampaignMember.UserId
                };
                db.CampaignMembers.Add(campaignMember);
                await db.SaveChangesAsync();
                var memberWithUserName = await db.CampaignMembers.Include(member => member.User).FirstAsync(member => member.Id == campaignMember.Id);
                var userDto = memberWithUserName.ToDetailsDto();
                return TypedResults.CreatedAtRoute(userDto, GetCampaignMemberEndpointName, new {campaignId = campaignId, id = campaignMember.Id});
            });
    }
}