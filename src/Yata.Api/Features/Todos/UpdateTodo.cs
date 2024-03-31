using FluentValidation;
using MediatR;
using Yata.Api.Data;

namespace Yata.Api.Features.Todos;

public static class UpdateTodo
{
    public record Command(string Name, string Description, DateTime? Deadline, bool Done) : IRequest<Guid>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }

    //internal sealed class Hander(ApplicationDbContext context, IValidator<Command> validator)
    //    : IRequestHandler<Command, Guid>
    //{
    //    public async Task<Guid> Handle(Command request, CancellationToken cancellationToken)
    //    {
    //    }
    //}
}
