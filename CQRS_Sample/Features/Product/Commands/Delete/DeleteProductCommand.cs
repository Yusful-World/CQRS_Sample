using MediatR;

namespace CQRS_Sample.Features.Product.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest
    {
    }
}
