using Microsoft.AspNetCore.Identity;
using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.Models;

public class CampaignMember
{
    public int Id { get; set; }
    
    public int CampaignId { get; set; }
    public Campaign Campaign { get; set; } = null!;
    
    public required string UserId { get; set; }
    public IdentityUser User { get; set; } = null!;
    
    public required UserType UserType { get; set; }
    
    public string? PersonalNotes { get; set; }
}