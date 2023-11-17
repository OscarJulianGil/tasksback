using System;
using MediatR;
using ServiceDesk.Application.Helpers;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Tasks.CompleteTask
{
	public class CompleteTaskCommandHandler : IRequestHandler<CompleteTaskRequest,Response>
	{
        private readonly ServiceDeskDbContext db;

        public CompleteTaskCommandHandler(ServiceDeskDbContext db)
        {
            this.db = db;
        }



        public async Task<Response> Handle(CompleteTaskRequest request, CancellationToken cancellationToken)
        {
            var task = db.Tasks.Find(new Guid(request.id));

            if (task is null)
                return new Response()
                {
                    Code = Enums.ApiResponses.NotFoundRecords,
                    Message = "Task not found"
                };

            task.IsCompleted = true;
            await db.SaveChangesAsync();

            return new Response()
            {
                Code = Enums.ApiResponses.Ok,
                Message = "Task completed successfully"
            };
        }
    }
}

