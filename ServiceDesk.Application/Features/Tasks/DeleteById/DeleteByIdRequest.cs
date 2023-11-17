using System;
using MediatR;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.Tasks.DeleteById
{
	public record DeleteByIdRequest(string Id) :IRequest<Response>;
}

