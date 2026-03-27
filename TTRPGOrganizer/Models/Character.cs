namespace TTRPGOrganizer.Models;

public class Character
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Appearance { get; set; }
    public string? Demeanor { get; set; }
    public string? Notes { get; set; }
}