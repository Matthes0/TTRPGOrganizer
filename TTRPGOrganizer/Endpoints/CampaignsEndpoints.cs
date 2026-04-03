using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TTRPGOrganizer.Data;
using TTRPGOrganizer.Models;
using TTRPGOrganizer.shared.DTOs;



namespace TTRPGOrganizer.Endpoints;

public static class CampaignsEndpoints
{
    private const string GetCampaignEndpointName = "GetCampaign";

    public static void MapCampaignsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/campaigns");
        // GET /campaigns
        group.MapGet("/", async (OrganizerContext db) =>
        {
            var campaigns = await db.Campaigns.ToListAsync();
            return TypedResults.Ok(campaigns);
        });
        // GET /campaigns/{id}
        group.MapGet("/{id:int}", async (int id, OrganizerContext db) =>
        {
            var campaign = await db.Campaigns.FindAsync(id);
            return TypedResults.Ok(campaign);
        }).WithName(GetCampaignEndpointName);
        
        // POST /campaigns
        group.MapPost("/", async (CreateCampaignDto newCampaign, OrganizerContext db) =>
        {
            var campaign = new Campaign()
            {
                Name = newCampaign.Name,
                RpgSystemId = newCampaign.RpgSystemId,
                UserType = newCampaign.UserType,
                Description = newCampaign.Description,
            };
            db.Campaigns.Add(campaign);
            await db.SaveChangesAsync();
            var campaignDto = new CampaignDetailsDto(
                campaign.Id,
                campaign.Name,
                campaign.RpgSystemId,
                campaign.UserType,
                campaign.Description,
                campaign.PersonalNotes
                );

            return TypedResults.CreatedAtRoute(campaignDto, GetCampaignEndpointName, new {id = campaignDto.Id});
        });
        // DELETE /campaigns/{id}
        group.MapDelete("/{id:int}", async Task<Results<NotFound, NoContent>> (int id, OrganizerContext db) =>
        {
            if (await db.Campaigns.Where(campaign => campaign.Id == id).ExecuteDeleteAsync() == 0)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.NoContent();
        });
    }
}