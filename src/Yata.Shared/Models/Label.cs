namespace Yata.Shared.Models;

public class Label
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Color { get; set; }
    public ICollection<Todo> Todos { get; set; } = [];
}