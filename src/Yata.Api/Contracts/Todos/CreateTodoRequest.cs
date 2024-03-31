namespace Yata.Api.Contracts.Todos;

public class CreateTodoRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime? Deadline { get; set; } = null;
}
