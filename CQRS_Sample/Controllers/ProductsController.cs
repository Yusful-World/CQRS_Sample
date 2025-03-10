using CQRS_Sample.Features.Product.Commands.Create;
using CQRS_Sample.Features.Product.Commands.Delete;
using CQRS_Sample.Features.Product.Commands.Update;
using CQRS_Sample.Features.Product.Queries.Get;
using CQRS_Sample.Features.Product.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Sample.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController(ISender sender) : ControllerBase 
    {
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productList = await sender.Send(new ListProductQuery());
            
            return Ok(productList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await sender.Send(new GetProductQuery(id));

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand createProductCommand)
        {
            var productId = await sender.Send(createProductCommand);
            if (Guid.Empty == productId)
            {
                return BadRequest("Error creating product");
            }

            return Created(nameof(GetProduct), new {id = productId});
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, UpdateProductCommand updateProductCommand)
        {
            var updatedProduct = await sender.Send(new UpdateProductRequest(id, updateProductCommand));
            
            return updatedProduct != null ? Ok(updatedProduct) : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await sender.Send(new DeleteProductCommand(id));
            

            return NoContent();
        }
    }
}
