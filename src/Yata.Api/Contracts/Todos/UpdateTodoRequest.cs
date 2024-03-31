namespace Yata.Api.Contracts.Todos;

public class UpdateTodoRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime? Deadline { get; set; }
    public bool Done { get; set; }
}
