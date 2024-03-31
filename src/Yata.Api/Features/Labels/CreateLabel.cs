using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Yata.Api.Contracts.Labels;
using Yata.Api.Data;
using Yata.Shared.Models;

namespace Yata.Api.Features.Labels;

public static class CreateLabel
{
    public record Command(string Name, string Description, string Color) : IRequest<Guid>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Color).NotEmpty();
        }
    }

    internal sealed class Handler(ApplicationDbContext context, IValidator<Command> validator)
        : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) { }

            var label = new Label()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Color = request.Color,
            };

            context.Add(label);

            await context.SaveChangesAsync(cancellationToken);

            return label.Id;
        }
    }
}

public class CreateLabelEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("label", async (CreateLabelRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateLabel.Command>();

            var labelId = await sender.Send(command);

            return Results.Ok(labelId);
        });
    }
}
