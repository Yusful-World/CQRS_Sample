using MediatR;

namespace CQRS_Sample.Features.Product.Commands.Create
{       
    public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>
    {
    }
}
