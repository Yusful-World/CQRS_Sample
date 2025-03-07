using CQRS_Sample.Features.Product.Dtos;
using MediatR;

namespace CQRS_Sample.Features.Product.Queries.List
{
    public record ListProductQuery : IRequest<List<ProductDto>>
    {
    }
}
