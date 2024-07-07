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

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _todoService.CreateTodoAsync(request);
            return Ok(new { message = "Blog post successfully created"});
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while creating the  crating Todo Item", error = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var todos = await _todoService.GetAllAsync();
            if (todos == null || !todos.Any())
            {
                return Ok(new { message = "No Todo Items found!"});
            }
            return Ok(new { message = "Successfully retrieved all blog posts", data = todos});
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, new {message = "An error occurred while retrieving all Todo it posts", error = ex.Message});
        }
    }
}
