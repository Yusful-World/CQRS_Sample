using CQRS_MinimalSample.Features.Product.Dtos;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Queries.List
{
    public record ListProductQuery : IRequest<List<ProductDto>>
    {
    }
}
