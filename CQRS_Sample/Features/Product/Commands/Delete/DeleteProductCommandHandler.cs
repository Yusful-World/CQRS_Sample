using CQRS_Sample.Persistence;
using MediatR;

namespace CQRS_Sample.Features.Product.Commands.Delete
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
