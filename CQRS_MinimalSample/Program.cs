using CQRS_MinimalSample.Features.Product.Command.Create;
using CQRS_MinimalSample.Features.Product.Command.Delete;
using CQRS_MinimalSample.Features.Product.Command.Update;
using CQRS_MinimalSample.Features.Product.Queries.Get;
using CQRS_MinimalSample.Features.Product.Queries.List;
using CQRS_MinimalSample.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/products/{id:guid}", async (Guid id, ISender mediatr) =>
{
    var product = await mediatr.Send(new GetProductQuery(id));
    if (product == null) return Results.NotFound();
    return Results.Ok(product);
});

app.MapGet("/products", async (ISender mediatr) =>
{
    var products = await mediatr.Send(new ListProductQuery());
    return Results.Ok(products);
});

app.MapPost("/products", async (CreateProductCommand command, ISender mediatr) =>
{
    var productId = await mediatr.Send(command);
    if (Guid.Empty == productId) return Results.BadRequest();
    return Results.Created($"/products/{productId}", new { id = productId });
});

app.MapPut("/products/{id:guid}", async (Guid id, UpdateProductCommand command, ISender mediatr) =>
{
    var updatedProduct = await mediatr.Send(new UpdateProductRequest(id, command));
    if (updatedProduct == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(updatedProduct);
});

app.MapDelete("/products/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteProductCommand(id));
    return Results.NoContent();
});

app.Run();

