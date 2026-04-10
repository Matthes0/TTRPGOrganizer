namespace TTRPGOrganizer.Models;

public class Handout
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Appearance { get; set; }
    public string? Notes { get; set; }
}