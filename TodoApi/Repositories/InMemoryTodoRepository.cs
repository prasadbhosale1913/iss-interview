using TodoApi.Models;

namespace TodoApi.Repositories;

public class InMemoryTodoRepository : ITodoRepository
{
    private readonly List<TodoItem> _todos = new();

    public IEnumerable<TodoItem> GetAll() => _todos;

    public TodoItem? GetById(Guid id) =>
        _todos.FirstOrDefault(t => t.Id == id);

    public void Add(TodoItem todo)
    {
        _todos.Add(todo);
    }

    public void Update(TodoItem todo)
    {
        var existing = GetById(todo.Id);
        if (existing == null) return;

        existing.Title = todo.Title;
        existing.IsCompleted = todo.IsCompleted;
    }

    public void Delete(Guid id)
    {
        var todo = GetById(id);
        if (todo != null)
            _todos.Remove(todo);
    }
}
