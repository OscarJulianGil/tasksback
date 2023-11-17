using System;
using ServiceDesk.Application.Helpers;
using ServiceDesk.Domain.Models;

namespace ServiceDesk.Application.Features.Tasks.SelectById
{
	public class SelectByIdResponse : Response
	{
		public TaskDTO? Data { get; set; }
    }


	public class TaskDTO
	{
        public Guid Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

