using System;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.Register
{
	public class RegisterResponse : Response
	{
		public string Id { get; set; } = string.Empty;
		public string token { get; set; } = string.Empty;
    }
}

