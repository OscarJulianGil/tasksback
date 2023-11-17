using System;
using MediatR;

namespace ServiceDesk.Application.Features.Categories.SelectAll
{
	public record SelectAllRequest : IRequest<SelectAllResponse>;
}

