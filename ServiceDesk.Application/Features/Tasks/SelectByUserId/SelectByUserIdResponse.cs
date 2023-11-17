using System;
using ServiceDesk.Application.Helpers;

namespace ServiceDesk.Application.Features.Tasks.SelectByUserId
{
	public class SelectByUserIdResponse : Response
	{
		public List<SelectByUserIdResponseDto>? Data { get; set; }
	}

	public class  SelectByUserIdResponseDto
	{
		public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
		public bool IsCompleted { get; set; }
        public DateTime DateFinish { get; set; }
    }
}

