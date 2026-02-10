using TodoApi.Models;

namespace TodoApi.Repositories;

public interface ITodoRepository
{
    IEnumerable<TodoItem> GetAll();
    TodoItem? GetById(Guid id);
    void Add(TodoItem todo);
    void Update(TodoItem todo);
    void Delete(Guid id);
}
