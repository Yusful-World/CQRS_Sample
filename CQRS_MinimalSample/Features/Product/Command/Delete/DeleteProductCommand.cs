using MediatR;

namespace CQRS_MinimalSample.Features.Product.Command.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest
    {
    }
}
