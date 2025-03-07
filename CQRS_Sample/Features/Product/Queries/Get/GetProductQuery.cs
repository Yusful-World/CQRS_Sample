using CQRS_Sample.Features.Product.Dtos;
using MediatR;

namespace CQRS_Sample.Features.Product.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>
    {
    }
}
