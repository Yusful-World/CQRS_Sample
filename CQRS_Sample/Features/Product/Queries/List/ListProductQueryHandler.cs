using CQRS_Sample.Features.Product.Dtos;
using CQRS_Sample.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Sample.Features.Product.Queries.List
{
    public class ListProductQueryHandler(AppDbContext context) : IRequestHandler<ListProductQuery, List<ProductDto>>
    {
        public async Task<List<ProductDto>> Handle(ListProductQuery request, CancellationToken cancellationToken)
        {
            return await context.Products
                .Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price))
                .ToListAsync();
        }
    }
}
