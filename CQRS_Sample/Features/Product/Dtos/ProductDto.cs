namespace CQRS_Sample.Features.Product.Dtos
{
    public record ProductDto (Guid Id, string Name, string Description, decimal Price)
    {
    }
}
