using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yata.Api.Contracts.Todos;
using Yata.Api.Data;
using Yata.Shared.Models;

namespace Yata.Api.Features.Todos;

public static class GetTodo
{
    public record Query(Guid Id) : IRequest<TodoResponse?>;

    internal sealed class Handler(ApplicationDbContext context) : IRequestHandler<Query, TodoResponse?>
    {
        public async Task<TodoResponse?> Handle(Query request, CancellationToken cancellationToken)
        {
            var todo = await context
                .Todos
                .Where(t => t.Id == request.Id)
                .Select(t => new TodoResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    CreatedAt = t.CreatedAt,
                    Deadline = t.Deadline,
                    Done = t.Done,
                }).FirstOrDefaultAsync(cancellationToken);

            return todo;
        }
    }
}

public class GetTodoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("todo/{id:Guid}", async (Guid id, ISender sender) =>
        {
            var query = new GetTodo.Query(id);

            var result = await sender.Send(query);

            return result is null ? Results.NotFound() : Results.Ok(result);
        })
            .WithTags(nameof(Todo));
    }
}
