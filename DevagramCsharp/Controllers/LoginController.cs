using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevagramCsharp.DTOs;
using DevagramCsharp.Models;
using DevagramCsharp.Services;

namespace DevagramCsharp.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class LoginController : BaseController
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
            if (!String.IsNullOrEmpty(requestLogin.Password) && !String.IsNullOrEmpty(requestLogin.Email) &&
                !String.IsNullOrWhiteSpace(requestLogin.Password) && !String.IsNullOrWhiteSpace(requestLogin.Email))
            {
                string email = "bruna.simoesmoita@gmail.com";
                string password = "Senha@123";

                if(requestLogin.Email == email && requestLogin.Password == password)
                {
                    User user = new User()
                    {
                        Email = requestLogin.Email,
                        Id = 12,
                        Name = "Bruna Simoes"
                    };

                    return Ok(new AnswerLoginDTO()
                    {
                        Email = user.Email,
                        Name = user.Name,
                        Token = TokerService.CreatToken(user),
                    });
                } else
                {
                    return BadRequest(new AnswerErrorDTO()
                    {
                        Description = "Invalid password or email",
                        Status = StatusCodes.Status400BadRequest
                    });
                }
            }
            else
            {
                return BadRequest(new AnswerErrorDTO()
                {
                    Description = "User did not fill in the login fields correctly",
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("There was an error logging in" + ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new AnswerErrorDTO()
            {
                Description = "There was an error while logging in",
                Status = StatusCodes.Status500InternalServerError
            });
        }
    }
}


