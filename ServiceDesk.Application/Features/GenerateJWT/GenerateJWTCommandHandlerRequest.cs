using System;
using MediatR;
using ServiceDesk.Domain.Models;

namespace ServiceDesk.Application.Features.GenerateJWT
{
	public record GenerateJWTCommandHandlerRequest(User User) : IRequest<GenerateJWTCommandHandlerResponse>;
}

