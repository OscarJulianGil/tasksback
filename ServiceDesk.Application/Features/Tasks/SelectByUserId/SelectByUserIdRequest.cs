using System;
using MediatR;

namespace ServiceDesk.Application.Features.Tasks.SelectByUserId
{
	public record SelectByUserIdRequest(string Id,string? categoryId): IRequest<SelectByUserIdResponse>;
}

