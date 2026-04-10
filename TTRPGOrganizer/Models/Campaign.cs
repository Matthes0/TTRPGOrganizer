using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.Models;

public class Campaign
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? GmNotes { get; set; }
    public string? SharedNotes { get; set; }
    public int? RpgSystemId { get; set; }
    public RpgSystem? RpgSystem { get; set; }
    
    public ICollection<CampaignMember> Members { get; set; } = new List<CampaignMember>();
    public ICollection<Character> Characters { get; set; } = new List<Character>();

}