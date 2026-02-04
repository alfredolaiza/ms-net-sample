using backend_api.Application.Products.Commands.CreateProduct;
using backend_api.Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<Ok<List<ProductDto>>> GetProducts()
    {
        var result = await _sender.Send(new GetProductsQuery());

        return TypedResults.Ok(result);
    }

    [HttpPost]
    public async Task<Created<int>> CreateProduct(CreateProductCommand command)
    {
        var id = await _sender.Send(command);

        return TypedResults.Created($"/Products/{id}", id);
    }
}
