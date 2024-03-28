namespace Yata.Shared.Models;

public class Todo
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string DateCreated { get; set; }
    public required string LastUpdated { get; set; }
    public bool Done { get; set; }
    public ICollection<Label> Labels { get; set; } = [];
}