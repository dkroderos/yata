using Carter;
using FluentValidation;
using Mapster;
using MediatR;
using Yata.Api.Contracts;
using Yata.Api.Data;
using Yata.Shared.Models;

namespace Yata.Api.Features.Todos;

public static class CreateTodo
{
    public class Command : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
        }
    }

    internal sealed class Handler(ApplicationDbContext context, IValidator<Command> validator) : IRequestHandler<Command, Guid>
    {
        public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
        {
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) { }

            var todo = new Todo
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                DateCreated = DateTimeOffset.Now.ToString("o"),
                LastUpdated = DateTimeOffset.Now.ToString("o"),
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
        app.MapPost("api/todo", async (CreateTodoRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateTodo.Command>();

            var todoId = await sender.Send(command);
            return Results.Ok(todoId);
        });
    }
}
