using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Application.Commands.CreateTodo;
using Tasks.Application.Commands.DeleteTodo;
using Tasks.Application.Commands.UpdateTodo;
using Tasks.Application.Queries.GetTodoById;
using Tasks.Application.Queries.GetTodos;

namespace Tasks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await mediator.Send(new GetTodosQuery());
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var todo = await mediator.Send(new GetTodoByIdQuery { Id = id });
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] CreateTodoCommand command)
        {
            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetTodoById), new { id }, null);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo([FromBody] UpdateTodoCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await mediator.Send(new DeleteTodoCommand { Id = id });
            return NoContent();
        }
    }
}
