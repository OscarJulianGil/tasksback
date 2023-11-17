using System;
using MediatR;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.Tasks.CompleteTask
{
	public record CompleteTaskRequest(string id):IRequest<Response>;
}

