using System;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.CreateTask
{
	public class CreateTaskResponse : Response
	{
		public Guid Id { get; set; }
	}
}

