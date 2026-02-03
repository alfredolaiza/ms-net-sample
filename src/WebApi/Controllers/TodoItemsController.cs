using backend_api.Application.Common.Models;
using backend_api.Application.TodoItems.Commands.CreateTodoItem;
using backend_api.Application.TodoItems.Commands.DeleteTodoItem;
using backend_api.Application.TodoItems.Commands.UpdateTodoItem;
using backend_api.Application.TodoItems.Commands.UpdateTodoItemDetail;
using backend_api.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<Ok<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
    {
        var result = await _sender.Send(query);

        return TypedResults.Ok(result);
    }

    [HttpPost]
    public async Task<Created<int>> CreateTodoItem(CreateTodoItemCommand command)
    {
        var id = await _sender.Send(command);

        return TypedResults.Created($"/TodoItems/{id}", id);
    }

    [HttpPut("{id}")]
    public async Task<Results<NoContent, BadRequest>> UpdateTodoItem( int id, UpdateTodoItemCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await _sender.Send(command);

        return TypedResults.NoContent();
    }

    [HttpPut("UpdateDetail/{id}")]
    public async Task<Results<NoContent, BadRequest>> UpdateTodoItemDetail(int id, UpdateTodoItemDetailCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await _sender.Send(command);

        return TypedResults.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<NoContent> DeleteTodoItem(int id)
    {
        await _sender.Send(new DeleteTodoItemCommand(id));

        return TypedResults.NoContent();
    }

}
