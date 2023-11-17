using System;
using MediatR;

namespace ServiceDesk.Application.Features.Tasks.SelectById
{
	public record SelectByIdRequest(string Id) : IRequest<SelectByIdResponse>;
}

