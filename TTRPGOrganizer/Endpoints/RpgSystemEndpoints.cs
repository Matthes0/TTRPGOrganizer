using Microsoft.EntityFrameworkCore;
using TTRPGOrganizer.Data;
using TTRPGOrganizer.Models;
using TTRPGOrganizer.shared.DTOs;

namespace TTRPGOrganizer.Endpoints;

public static class RpgSystemEndpoints
{
    const string GetRpgSystemEndpointName = "GetRpgSystem";

    public static void MapRpgSystemEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/rpgsystem");
        // GET /rpgsystem
        group.MapGet("/", async (OrganizerContext db) =>
        {
            var rpgSystems = await db.RpgSystems.ToListAsync();
            return TypedResults.Ok(rpgSystems);
        });
        // GET /rpgsystem/{id}
        group.MapGet("/{id:int}", async (int id, OrganizerContext db) =>
        {
            var rpgSystem = await db.RpgSystems.FindAsync(id);
            return TypedResults.Ok(rpgSystem);
        }).WithName(GetRpgSystemEndpointName);
        // POST /rpgsystem
        group.MapPost("/", async (CreateRpgSystemDto newRpgSystem, OrganizerContext db) =>
        {
            RpgSystem rpgSystem = new RpgSystem()
            {
                Name = newRpgSystem.Name,
                ShortName = newRpgSystem.ShortName,
                Description = newRpgSystem.Description
            };
            db.RpgSystems.Add(rpgSystem);
            await db.SaveChangesAsync();
            RpgSystemDetailsDto rpgSystemDto = new RpgSystemDetailsDto(
            rpgSystem.Id,
            rpgSystem.Name,
            rpgSystem.ShortName,
            rpgSystem.Description);
            return TypedResults.CreatedAtRoute(rpgSystemDto, GetRpgSystemEndpointName, new {id = rpgSystemDto.Id});

        });
        
    }
}