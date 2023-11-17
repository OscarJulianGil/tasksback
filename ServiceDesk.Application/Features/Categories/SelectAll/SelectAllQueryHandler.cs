using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Infrastructure.Repository;

namespace ServiceDesk.Application.Features.Categories.SelectAll
{
	public class SelectAllQueryHandler : IRequestHandler<SelectAllRequest, SelectAllResponse>
	{
        private readonly ServiceDeskDbContext db;
        public SelectAllQueryHandler(ServiceDeskDbContext db)
		{
            this.db = db;
        }

        public async Task<SelectAllResponse> Handle(SelectAllRequest request, CancellationToken cancellationToken)
        {

            var list = (from db in db.Categories select new SelectAllDTO()
            {
                Id = db.Id.ToString(),
                Value = db.Name
            }).ToList();

            return new SelectAllResponse() {
                Code = Enums.ApiResponses.Ok,
                Message = "Transaction successfully",
                Data = list
            };
            
        }
    }
}

