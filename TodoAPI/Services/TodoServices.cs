using AutoMapper;
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
    public Task CreateTodoAsync(CreateTodoRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTodoAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Todo>> GetAllAsync()
    {
        throw new NotImplementedException();
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
