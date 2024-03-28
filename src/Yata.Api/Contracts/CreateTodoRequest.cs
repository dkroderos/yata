namespace Yata.Api.Contracts;

public class CreateTodoRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
