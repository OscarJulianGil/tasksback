using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceDesk.Application.Features.CreateTask;
using ServiceDesk.Application.Features.Login;
using ServiceDesk.Application.Features.Tasks.CompleteTask;
using ServiceDesk.Application.Features.Tasks.DeleteById;
using ServiceDesk.Application.Features.Tasks.SelectById;
using ServiceDesk.Application.Features.Tasks.SelectByUserId;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceDesk.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly IMediator Mediator;

        public TaskController(IMediator mediator)
        {
            this.Mediator = mediator;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequest request)
        {

            if (request is null)
                return BadRequest();

            var result = await Mediator.Send(request);
            return Ok(result);
        }


        [HttpGet]
        [Route("getBy/{id}")]
        public async Task<IActionResult> getById(string id)
        {

            if (id == null)
                return BadRequest();

            var result = await Mediator.Send(new SelectByIdRequest(id));
            return Ok(result);
        }

        [HttpGet]
        [Route("user/{id}/{categoryId?}")]
        public async Task<IActionResult> getByUserId(string id,string? categoryId)
        {

            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var result = await Mediator.Send(new SelectByUserIdRequest(id, categoryId));
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {

            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var result = await Mediator.Send(new DeleteByIdRequest(id));
            return Ok(result);
        }

        [HttpPatch]
        [Route("update/status/{id}")]
        public async Task<IActionResult> CompletedTask(string id)
        {

            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var result = await Mediator.Send(new CompleteTaskRequest(id));
            return Ok(result);
        }
    }
}

