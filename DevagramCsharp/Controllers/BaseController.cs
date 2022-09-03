using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DevagramCsharp.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
    }
}

