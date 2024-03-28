using MediatR;
using Yata.Api.Data;
using Yata.Shared.Models;

namespace Yata.Api.Features.Todos;

public static class CreateTodo
{
    public class Command : IRequest<Todo>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    internal sealed class Handler(ApplicationDbContext context) : IRequestHandler<Command, Todo>
    {
        public async Task<Todo> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
