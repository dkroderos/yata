using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Yata.Api.Contracts.Labels;
using Yata.Api.Data;
using Yata.Shared.Models;

namespace Yata.Api.Features.Labels;

public class GetLabels
{
    public record Query() : IRequest<IEnumerable<LabelResponse>>;

    internal sealed class Handler(ApplicationDbContext context) : IRequestHandler<Query, IEnumerable<LabelResponse>>
    {
        public async Task<IEnumerable<LabelResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var labels = await context.Labels
                .Select(l => new LabelResponse()
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    Color = l.Color,
                }).ToListAsync(cancellationToken);

            return labels;
        }
    }
}

public class GetLabelsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("label", async (ISender sender) =>
        {
            var query = new GetLabels.Query();

            var result = await sender.Send(query);

            return result is null ? Results.NotFound() : Results.Ok(result);
        })
            .WithTags(nameof(Label));
    }
}
