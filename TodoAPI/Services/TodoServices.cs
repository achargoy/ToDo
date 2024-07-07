using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPI.AppDataContext;
using TodoAPI.Interfaces;
using TodoAPI.Models;

namespace TodoAPI.Services;

public class TodoServices : ITodoServices
{
    private readonly TodoDbContext _dbContext;
    private readonly ILogger<TodoServices> _logger;
    private readonly IMapper _mapper;
    public TodoServices(TodoDbContext todoDbContext, ILogger<TodoServices> logger, IMapper mapper)
    {
        _dbContext = todoDbContext;
        _logger = logger;
        _mapper = mapper;
    }
    public async Task CreateTodoAsync(CreateTodoRequest request)
    {
        try
        {
            var todo = _mapper.Map<Todo>(request);
            todo.CreatedAt = DateTime.UtcNow;
            _dbContext.Todos.Add(todo);
            await _dbContext.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the Todo item.");
            throw new Exception("An error occurred while creating the Todo item.");
        }
    }

    public async Task DeleteTodoAsync(Guid id)
    {
        var todo = await _dbContext.Todos.FindAsync(id);
        if (todo != null)
        {
            _dbContext.Remove(todo);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new Exception($"No  item found with the id {id}");
        }
    }

    public async Task<IEnumerable<Todo>> GetAllAsync()
    {
        var todo = await _dbContext.Todos.ToListAsync();
        if (todo == null)
        {
            throw new Exception(" No Todo items found");
        }
        return todo;
    }

    public async Task<Todo> GetByIdAsync(Guid id)
    {
        var todo = await _dbContext.Todos.FindAsync(id);
        if (todo == null)
        {
            throw new KeyNotFoundException($"No Todo item with Id {id} found.");
        }
        return todo;
    }

    public async Task UpdateTodoAsync(Guid id, UpdateTodoRequest request)
    {
        try
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if(todo == null)
            {
                throw new Exception($"Todo item with id {id} not found.");
            }

            if (request.Title != null)
            {
                todo.Title = request.Title;
            }
            if (request.Description != null)
            {
                todo.Description = request.Description;
            }
            if (request.IsComplete != null)
            {
                todo.IsComplete = request.IsComplete.Value;
            }
            if (request.DueDate != null)
            {
                todo.DueDate = request.DueDate.Value;
            }
            if (request.Priority != null)
            {
                todo.Priority = request.Priority.Value;
            }

            todo.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, $"An error occurred while updating the todo item with id {id}.");
            throw;
        }
    }
}
