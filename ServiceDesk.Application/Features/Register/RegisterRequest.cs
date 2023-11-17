using System;
using MediatR;

namespace ServiceDesk.Application.Features.Register
{
	public record RegisterRequest(string Name,string Email,string Password):IRequest<RegisterResponse>;
}

