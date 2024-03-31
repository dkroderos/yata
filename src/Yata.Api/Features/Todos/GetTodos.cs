using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yata.Api.Contracts.Todos;
using Yata.Api.Data;

namespace Yata.Api.Features.Todos;

public static class GetTodos
{
    public record Query() : IRequest<IEnumerable<TodoResponse>>;

    internal sealed class Handler(ApplicationDbContext context) : IRequestHandler<Query, IEnumerable<TodoResponse>>
    {
        public async Task<IEnumerable<TodoResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var todos = await context.Todos
                .Select(t => new TodoResponse()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    CreatedAt = t.CreatedAt,
                    Deadline = t.Deadline,
                    Done = t.Done,
                })
                .ToListAsync(cancellationToken);

            return todos;
        }
    }
}

public class GetTodosEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("todo", async (ISender sender) =>
        {
            var query = new GetTodos.Query();

            var result = await sender.Send(query);

            return result is null ? Results.NotFound() : Results.Ok(result);
        });
    }
}
