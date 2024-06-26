using System.ComponentModel.DataAnnotations;

namespace Yata.Shared.Models;

public class Todo
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? Deadline { get; set; }
    public bool Done { get; set; }
    public ICollection<Label> Labels { get; } = [];
}