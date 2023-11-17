using System;
using MediatR;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Tasks.SelectByUserId
{
	public class SelectByUserIdQueryHandler : IRequestHandler<SelectByUserIdRequest,SelectByUserIdResponse>
	{
        private readonly ServiceDeskDbContext db;
        public SelectByUserIdQueryHandler(ServiceDeskDbContext db)
		{
            this.db = db;
        }

        public  async Task<SelectByUserIdResponse> Handle(SelectByUserIdRequest request, CancellationToken cancellationToken)
        {
            var list = (from t in db.Tasks
                        join
                        c in db.Categories on t.CategoryId equals c.Id
                        where t.UserAssignedId.ToString() == request.Id
                        &&
                        ((request.categoryId != null && t.CategoryId == new Guid(request.categoryId.ToString())) || request.categoryId == null)
                        select new SelectByUserIdResponseDto()
                        {
                            Id = t.Id.ToString(),
                            Description = t.Description,
                            Category = c.Name,
                            DateFinish = t.FinishLimitResponse,
                            Name = t.TaskName,
                            IsCompleted = t.IsCompleted
                        }).ToList();



            return new SelectByUserIdResponse()
            {
                Code = Enums.ApiResponses.Ok,
                Message = "Operation succesfully",
                Data = list
            };
        }
    }
}

