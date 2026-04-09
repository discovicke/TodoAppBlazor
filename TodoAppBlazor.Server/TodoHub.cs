using Microsoft.AspNetCore.SignalR;

namespace TodoAppBlazor.Server;

public class TodoService
{
    public List<Todo> TodoItems { get; } = new List<Todo>();
}

public class TodoHub(TodoService todoService) : Hub
{
    public async Task UpdateTodo(Todo todo)
    {
        var existing = todoService.TodoItems.FirstOrDefault(t => t.Id == todo.Id);
        if (existing != null)
        {
            existing.Text = todo.Text;
            existing.IsDone = todo.IsDone;
        }
        else
        {
            todoService.TodoItems.Add(todo);
        }
        await Clients.Others.SendAsync("UpdateTodo", todo);
    }
}

public class Todo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Text { get; set; } = "";
    public bool IsDone { get; set; } = false;
}