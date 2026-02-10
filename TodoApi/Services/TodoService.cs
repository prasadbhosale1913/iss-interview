using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<TodoItem> GetTodos()
    {
        return _repository.GetAll();
    }

    public TodoItem GetTodo(Guid id)
    {
        var todo = _repository.GetById(id);
        if (todo == null)
            throw new KeyNotFoundException("Todo not found");

        return todo;
    }

    public TodoItem Create(CreateTodoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
            throw new ArgumentException("Title is required");

        var todo = new TodoItem
        {
            Title = request.Title
        };

        _repository.Add(todo);
        return todo;
    }

    public void Update(Guid id, UpdateTodoRequest request)
    {
        var todo = GetTodo(id);

        todo.Title = request.Title;
        todo.IsCompleted = request.IsCompleted;

        _repository.Update(todo);
    }

    public void Delete(Guid id)
    {
        GetTodo(id);
        _repository.Delete(id);
    }
}
