using CQRS_Sample.Features.Product.Dtos;
using MediatR;

namespace CQRS_Sample.Features.Product.Commands.Update
{
    public record UpdateProductRequest(Guid Id, UpdateProductCommand Command) : IRequest<ProductDto>
    {
    }
}
