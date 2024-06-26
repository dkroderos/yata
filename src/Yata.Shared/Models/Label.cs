using System.ComponentModel.DataAnnotations;

namespace Yata.Shared.Models;

public class Label
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Color { get; set; }
    public ICollection<Todo> Todos { get; } = [];
}