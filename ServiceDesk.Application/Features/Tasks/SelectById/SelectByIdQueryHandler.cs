using System;
using MediatR;
using ServiceDesk.Application.Features.CreateTask;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Tasks.SelectById
{
	public class SelectByIdQueryHandler : IRequestHandler<SelectByIdRequest, SelectByIdResponse>
    {

        private readonly ServiceDeskDbContext db;

        public SelectByIdQueryHandler(ServiceDeskDbContext db, IMediator mediator)
        {
            this.db = db;
        }

        public async Task<SelectByIdResponse> Handle(SelectByIdRequest request, CancellationToken cancellationToken)
        {
            var exists = (from db in db.Tasks
                          where db.Id.ToString() == request.Id
                          select new TaskDTO()
                          {
                              Description = db.Description,
                              TaskName = db.TaskName,
                              Id = db.Id

                          }).FirstOrDefault();


            return new SelectByIdResponse()
            {
                Code = Enums.ApiResponses.Ok,
                Message = "Operation succesfully",
                Data = exists
            };
        }
    }
}

