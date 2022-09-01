using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevagramCsharp.DTOs;

namespace DevagramCsharp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;

    public LoginController (ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [AllowAnonymous]

    public IActionResult MakeLogin([FromBody] RequestLoginDTO requestLogin)
    {
        try
        {
            throw new ArgumentException("Error filling data");
        }
        catch (Exception ex)
        {
            _logger.LogError("There was an error logging in" + ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new AnswerErrorDTO()
            {
                Description = "There was an error while logging in,
                Status = StatusCodes.Status500InternalServerError
            });
        }
    }
}


