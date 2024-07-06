using Microsoft.AspNetCore.Mvc;
using TodoAPI.Interfaces;

namespace TodoAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoServices _todoService;
    public TodoController(ITodoServices todoServices)
    {
        _todoService = todoServices;
    }
}
