using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
    IEnumerable<TodoItem> GetTodos();
    TodoItem GetTodo(Guid id);
    TodoItem Create(CreateTodoRequest request);
    void Update(Guid id, UpdateTodoRequest request);
    void Delete(Guid id);
}
