using Microsoft.AspNetCore.SignalR;

namespace TodoAppBlazor.Server;

public class TodoHub : Hub
{
    public List<Todo> TodoItems { get; set; } = new List<Todo>();

    public async Task UpdateTodo(Todo todo)
    {
        TodoItems.Add(todo);
        await Clients.All.SendAsync("UpdateTodo", todo);
    }
}

public class Todo
{
    public string Text { get; set; } = "";
    public bool IsDone { get; set; } = false;
}