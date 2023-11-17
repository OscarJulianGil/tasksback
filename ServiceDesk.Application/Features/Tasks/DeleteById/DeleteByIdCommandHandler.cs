using System;
using MediatR;
using ServiceDesk.Application.Helpers;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Tasks.DeleteById
{
	public class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdRequest, Response>
	{

        private readonly ServiceDeskDbContext db;

        public DeleteByIdCommandHandler(ServiceDeskDbContext db, IMediator mediator)
        {
            this.db = db;
        }

        public async Task<Response> Handle(DeleteByIdRequest request, CancellationToken cancellationToken)
        {
            Domain.Models.Task? task =await db.Tasks.FindAsync(new Guid(request.Id));
            if(task is not null)
            {
                db.Tasks.Remove(task);
                await db.SaveChangesAsync();
                return new Response()
                {
                    Code = Enums.ApiResponses.Ok,
                    Message = "Transaction successfully"
                };
            }
            else
            {
                return new Response()
                {
                    Code = Enums.ApiResponses.NotFoundRecords,
                    Message = "Task not found"
                };
            }
        }
    }
}

