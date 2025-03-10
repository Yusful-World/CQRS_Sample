using CQRS_MinimalSample.Infrastructure;
using MediatR;

namespace CQRS_MinimalSample.Features.Product.Command.Delete
{
    public class DeleteProductCommandHandler(AppDbContext context)
        : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand command, CancellationToken token)
        {
            var product = await context.Products.FindAsync(command.Id);

            if (product == null)
            {
                return;
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
