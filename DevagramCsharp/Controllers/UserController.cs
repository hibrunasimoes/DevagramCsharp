using System;
using DevagramCsharp.DTOs;
using DevagramCsharp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace DevagramCsharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {

        public readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]

        public IActionResult GetUser()
        {
            try
            {
                User user = new User()
                {
                    Email = "bruna.simoesmoita@gmail.com",
                    Name = "Bruna",
                    Id = 100
                };

                return Ok(user);
            }

            catch (Exception e)
            {
                _logger.LogError("Erro ao obter usuario");
                return StatusCode(StatusCodes.Status500InternalServerError, new AnswerErrorDTO()
                {
                    Description = "Ocorreu o seguinte erro" + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

    }
}

