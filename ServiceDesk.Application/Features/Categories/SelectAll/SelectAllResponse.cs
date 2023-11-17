using System;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.Categories.SelectAll
{
	public class SelectAllResponse : Response
	{
		public List<SelectAllDTO>? Data { get; set; }
	}

	public class SelectAllDTO
	{
		public string Id { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}

