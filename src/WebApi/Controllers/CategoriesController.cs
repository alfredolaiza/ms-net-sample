
using backend_api.Application.Categories.Commands.CreateCategory;
using backend_api.Application.Categories.Commands.DeleteCategory;
using backend_api.Application.Categories.Commands.UpdateCategory;
using backend_api.Application.Categories.Queries.GetCategories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<Ok<List<CategoryDto>>> GetCategories()
    {
        var result = await _sender.Send(new GetCategoriesQuery());

        return TypedResults.Ok(result);
    }

    [HttpPost]
    public async Task<Created<int>> CreateCategory(CreateCategoryCommand command)
    {
        var id = await _sender.Send(command);

        return TypedResults.Created($"/Categories/{id}", id);
    }

    [HttpPut("{id}")]
    public async Task<Results<NoContent, BadRequest>> UpdateCategory(int id, UpdateCategoryCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await _sender.Send(command);

        return TypedResults.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<NoContent> DeleteCategory(int id)
    {
        await _sender.Send(new DeleteCategoryCommand(id));

        return TypedResults.NoContent();
    }
}
