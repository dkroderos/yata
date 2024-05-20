using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Yata.Api.Contracts.Todos;
using Yata.Api.Data;
using Yata.Shared.Models;

namespace Yata.Api.Features.Todos;

public static class CreateTodo
{
    public record Command(string Name, string Description, DateTime? Deadline) : IRequest<Guid>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }

    internal sealed class Handler(ApplicationDbContext context, IValidator<Command> validator)
        : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) { }

            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow,
                Deadline = request.Deadline,
                Done = false,
            };

            context.Add(todo);

            await context.SaveChangesAsync(cancellationToken);

            return todo.Id;
        }
    }
}

public class CreateTodoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("todo", async (CreateTodoRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateTodo.Command>();

            var todoId = await sender.Send(command);

            return Results.Ok(todoId);
        })
            .WithTags(nameof(Todo));
    }
}