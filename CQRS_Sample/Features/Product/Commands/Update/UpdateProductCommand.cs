using CQRS_Sample.Features.Product.Dtos;
using MediatR;

namespace CQRS_Sample.Features.Product.Commands.Update
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<ProductDto> 
    {
    }
}
