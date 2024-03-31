using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yata.Api.Contracts.Labels;
using Yata.Api.Data;
using Yata.Api.Features.Todos;

namespace Yata.Api.Features.Labels;

public static class GetLabel
{
    public record Query(Guid Id) : IRequest<LabelResponse?>;

    internal sealed class Handler(ApplicationDbContext context) : IRequestHandler<Query, LabelResponse?>
    {
        public async Task<LabelResponse?> Handle(Query request, CancellationToken cancellationToken)
        {
            var label = await context
                .Labels
                .Where(l => l.Id == request.Id)
                .Select(l => new LabelResponse()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Color = l.Color,
                }).FirstOrDefaultAsync(cancellationToken);

            return label;
        }
    }
}

public class GetLabelEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("label/{id:Guid}", async (Guid id, ISender sender) =>
        {
            var query = new GetLabel.Query(id);

            var result = await sender.Send(query);

            return result is null ? Results.NotFound() : Results.Ok(result);
        });
    }
}
