using backend_api.Application.TodoLists.Commands.CreateTodoList;
using backend_api.Application.TodoLists.Commands.DeleteTodoList;
using backend_api.Application.TodoLists.Commands.UpdateTodoList;
using backend_api.Application.TodoLists.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<Ok<TodosVm>> GetTodoLists()
    {
        var vm = await _sender.Send(new GetTodosQuery());

        return TypedResults.Ok(vm);
    }

    [HttpGet("{id}")]
    public Task<Ok<TodosVm>> GetTodoListById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<Created<int>> CreateTodoList(CreateTodoListCommand command)
    {
        var id = await _sender.Send(command);

        return TypedResults.Created($"/TodoLists/{id}", id);
    }

    [HttpPut("{id}")]
    public async Task<Results<NoContent, BadRequest>> UpdateTodoList(int id, UpdateTodoListCommand command)
    {
        if (id != command.Id) return TypedResults.BadRequest();

        await _sender.Send(command);

        return TypedResults.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<NoContent> DeleteTodoList( int id)
    {
        await _sender.Send(new DeleteTodoListCommand(id));

        return TypedResults.NoContent();
    }
}
