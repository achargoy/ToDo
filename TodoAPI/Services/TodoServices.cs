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

    public Task DeleteTodoAsync(Guid id)
    {
        throw new NotImplementedException();
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

    public Task<Todo> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTodoAsync(Guid id, UpdateTodoRequest request)
    {
        throw new NotImplementedException();
    }
}
