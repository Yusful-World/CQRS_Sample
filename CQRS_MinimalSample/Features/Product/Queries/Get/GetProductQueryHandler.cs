using CQRS_MinimalSample.Features.Product.Dtos;
using CQRS_MinimalSample.Infrastructure;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Queries.Get
{
    public class GetProductQueryHandler(AppDbContext context) : IRequestHandler<GetProductQuery, ProductDto?>
    {
        public async Task<ProductDto?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return null;
            }

            return new ProductDto(product.Id, product.Name, product.Description, product.Price);

        }
    }
}
