using System;
using MediatR;
using ServiceDesk.Application.Features.Login;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.CreateTask
{
	public class CreateTaskCommandHandler : IRequestHandler<CreateTaskRequest, CreateTaskResponse>
    {
        private readonly ServiceDeskDbContext db;

        public CreateTaskCommandHandler(ServiceDeskDbContext db, IMediator mediator)
        {
            this.db = db;
        }


        public async Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.Task newTask = new Domain.Models.Task();

            newTask.TaskName = request.TaskName;
            newTask.Description = request.Description;
            newTask.FinishLimitResponse = request.DateResponse;
            newTask.UserAssignedId =  request.UserAssignedId;
            newTask.CategoryId = request.CategoryId;
            db.Tasks.Add(newTask);

            await db.SaveChangesAsync();

            return new CreateTaskResponse()
            {
                Code = Enums.ApiResponses.Ok,
                Message = "Task created sucessfully",
                Id = newTask.Id
            };
        }
    }
}

