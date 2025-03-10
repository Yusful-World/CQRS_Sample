using MediatR;
using CQRS_MinimalSample.Features.Product.Dtos;

namespace CQRS_MinimalSample.Features.Product.Command.Update
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<ProductDto>
    {
    }
}
