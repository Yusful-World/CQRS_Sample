using CQRS_MinimalSample.Features.Product.Dtos;
using CQRS_MinimalSample.Infrastructure;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Command.Update
{
    public class UpdateProductCommandHandler(AppDbContext context)
        : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(request.Id);
            if (product == null)
            {
                return null;
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;

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
