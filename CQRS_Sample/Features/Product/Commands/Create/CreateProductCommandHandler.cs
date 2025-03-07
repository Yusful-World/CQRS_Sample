using CQRS_Sample.Domain;
using CQRS_Sample.Persistence;
using MediatR;

namespace CQRS_Sample.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler(AppDbContext context)
        : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Domain.Product(command.Name, command.Description, command.Price);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product.Id;
        }
    }
}
