using System;
using MediatR;

namespace ServiceDesk.Application.Features.CreateTask
{
	public class CreateTaskRequest : IRequest<CreateTaskResponse>
	{

        public string TaskName { get; set; }
        public string Description { get; set; }
        public Guid UserAssignedId { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime DateResponse { get; set; }

    } 
}

