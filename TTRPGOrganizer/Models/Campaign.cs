using TTRPGOrganizer.shared.Enums;

namespace TTRPGOrganizer.Models;

public class Campaign
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required UserType UserType { get; set; }
    public string? Description { get; set; }
    public string? PersonalNotes { get; set; }
    
    public int? RpgSystemId { get; set; }
    public RpgSystem? RPGSystem { get; set; }
    public Character[]? Characters { get; set; }
}