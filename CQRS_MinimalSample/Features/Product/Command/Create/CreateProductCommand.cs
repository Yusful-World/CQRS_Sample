using MediatR;

namespace CQRS_MinimalSample.Features.Product.Command.Create
{
    public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>
    {
    }
}
