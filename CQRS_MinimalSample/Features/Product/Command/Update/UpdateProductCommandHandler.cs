using CQRS_MinimalSample.Features.Product.Dtos;
using CQRS_MinimalSample.Infrastructure;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Command.Update
{
    public class UpdateProductCommandHandler(AppDbContext context)
        : IRequestHandler<UpdateProductRequest, ProductDto>
    {
        public async Task<ProductDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return null;
            }

            product.Name = request.Command.Name;
            product.Description = request.Command.Description;
            product.Price = request.Command.Price;

            await context.SaveChangesAsync();

            return new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price
            );
        }
    }
}
