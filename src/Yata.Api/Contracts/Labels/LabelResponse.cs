namespace Yata.Api.Contracts.Labels;

public class LabelResponse
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Color { get; set; }
}
