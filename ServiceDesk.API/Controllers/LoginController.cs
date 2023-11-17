using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Application.Features.Login;
using ServiceDesk.Application.Features.Register;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceDesk.API.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IMediator Mediator;

        public LoginController(IMediator mediator)
        {
            this.Mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {

            if (request is null)
                return BadRequest();

            var result = await Mediator.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {

            if (request is null)
                return BadRequest();

            var result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}

