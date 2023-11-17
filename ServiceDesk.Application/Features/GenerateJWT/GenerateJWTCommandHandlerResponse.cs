using System;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.GenerateJWT
{
	public class GenerateJWTCommandHandlerResponse : Response
	{
		public string Token { get; set; } = string.Empty;
	}
}

