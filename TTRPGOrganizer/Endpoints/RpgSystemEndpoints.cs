using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TTRPGOrganizer.Data;
using TTRPGOrganizer.Models;
using TTRPGOrganizer.shared.DTOs;

namespace TTRPGOrganizer.Endpoints;

public static class RpgSystemEndpoints
{
    private const string GetRpgSystemEndpointName = "GetRpgSystem";

    public static void MapRpgSystemEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/rpg-systems");
        // GET /rpg-systems
        group.MapGet("/", async (OrganizerContext db) =>
        {
            var rpgSystems = await db.RpgSystems.ToListAsync();
            return TypedResults.Ok(rpgSystems);
        });
        // GET /rpg-systems/{id}
        group.MapGet("/{id:int}", async (int id, OrganizerContext db) =>
        {
            var rpgSystem = await db.RpgSystems.FindAsync(id);
            return TypedResults.Ok(rpgSystem);
        }).WithName(GetRpgSystemEndpointName);
        // POST /rpg-systems
        group.MapPost("/", async (CreateRpgSystemDto newRpgSystem, OrganizerContext db) =>
        {
            var rpgSystem = new RpgSystem()
            {
                Name = newRpgSystem.Name,
                ShortName = newRpgSystem.ShortName,
                Description = newRpgSystem.Description
            };
            db.RpgSystems.Add(rpgSystem);
            await db.SaveChangesAsync();
            var rpgSystemDto = new RpgSystemDetailsDto(
            rpgSystem.Id,
            rpgSystem.Name,
            rpgSystem.ShortName,
            rpgSystem.Description);
            return TypedResults.CreatedAtRoute(rpgSystemDto, GetRpgSystemEndpointName, new {id = rpgSystemDto.Id});
        });
        // DELETE /rpg-systems/{id}
        group.MapDelete("/{id:int}", async Task<Results<NotFound,NoContent>> (int id, OrganizerContext db) =>
        {
            if (await db.RpgSystems.Where(rpgSystem => rpgSystem.Id == id).ExecuteDeleteAsync() == 0)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.NoContent();
        });
        // PATCH /rpg-systems/{id}
        group.MapPatch("/{id:int}", async Task<Results<NotFound, NoContent>>(int id, PatchRpgSystemDto updatedRpgSystem, OrganizerContext db) =>
        {
            var rpgSystem = await db.RpgSystems.FindAsync(id);
            if (rpgSystem is null) return TypedResults.NotFound();
            if (updatedRpgSystem.Name is not null) rpgSystem.Name = updatedRpgSystem.Name;
            if (updatedRpgSystem.ShortName is not null) rpgSystem.ShortName = updatedRpgSystem.ShortName;
            if (updatedRpgSystem.Description is not null) rpgSystem.Description = updatedRpgSystem.Description;
            await  db.SaveChangesAsync();
            return TypedResults.NoContent();
        });
    }
}