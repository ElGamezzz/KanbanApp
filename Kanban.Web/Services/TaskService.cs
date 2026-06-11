using Kanban.Web.Models;
using System.Net.Http.Json;

namespace Kanban.Web.Services;

public class TaskService
{
    private readonly HttpClient _http;

    // HttpClient se inyecta automáticamente
    public TaskService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<TaskItem>> GetTasksAsync()
    {
        // Llama a GET /api/tasks
        return await _http.GetFromJsonAsync<List<TaskItem>>("api/tasks") ?? new List<TaskItem>();
    }

    public async Task<TaskItem> CreateTaskAsync(TaskItem task)
    {
        // Llama a POST /api/tasks
        var response = await _http.PostAsJsonAsync("api/tasks", task);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TaskItem>() ?? new TaskItem();
    }

    public async Task UpdateTaskAsync(TaskItem task)
    {
        // Llama a PUT /api/tasks/{id}
        await _http.PutAsJsonAsync($"api/tasks/{task.Id}", task);
    }

    public async Task DeleteTaskAsync(int id)
    {
        // Llama a DELETE /api/tasks/{id}
        await _http.DeleteAsync($"api/tasks/{id}");
    }
}