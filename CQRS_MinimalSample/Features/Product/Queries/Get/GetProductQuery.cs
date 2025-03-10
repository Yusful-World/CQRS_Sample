using CQRS_MinimalSample.Features.Product.Dtos;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Queries.Get
{
    public record GetProductQuery(Guid Id) : IRequest<ProductDto>
    {
    }
}
