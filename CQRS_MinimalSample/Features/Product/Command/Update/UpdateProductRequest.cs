using CQRS_MinimalSample.Features.Product.Dtos;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Command.Update
{
    public record UpdateProductRequest(Guid Id, UpdateProductCommand Command) : IRequest<ProductDto>
    {
    }
}
