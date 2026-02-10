using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/todos")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _service;

    public TodosController(ITodoService service)
    {
        _service = service;
    }

    // GET: api/todos
    [HttpGet]
    public IActionResult GetAll()
    {
        var todos = _service.GetTodos();
        return Ok(todos);
    }

    // GET: api/todos/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var todo = _service.GetTodo(id);
        return Ok(todo);
    }

    // POST: api/todos
    [HttpPost]
    public IActionResult Create([FromBody] CreateTodoRequest request)
    {
        var todo = _service.Create(request);
        return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
    }

    // PUT: api/todos/{id}
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] UpdateTodoRequest request)
    {
        _service.Update(id, request);
        return NoContent();
    }

    // DELETE: api/todos/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
