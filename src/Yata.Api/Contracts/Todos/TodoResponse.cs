using Yata.Shared.Models;

namespace Yata.Api.Contracts.Todos;

public class TodoResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? Deadline { get; set; }
    public bool Done { get; set; }
}
