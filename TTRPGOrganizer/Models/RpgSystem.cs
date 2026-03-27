namespace TTRPGOrganizer.Models;

public class RpgSystem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ShortName { get; set; }
    public string? Description { get; set; }
    
}