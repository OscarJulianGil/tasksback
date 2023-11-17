using System;
using ServiceDesk.Application.Enums;

namespace ServiceDesk.Application.Helpers
{
	public class Response
	{
		public ApiResponses Code { get; set; }
		public string Message { get; set; } = string.Empty;
    }
}

