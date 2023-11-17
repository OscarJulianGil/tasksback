using System;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.Login
{
	public class LoginResponse : Response
	{
		public string Token { get; set; } = string.Empty;
		public string Id { get; set; } = string.Empty;
    }
}

