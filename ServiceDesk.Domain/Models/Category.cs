using System;
namespace ServiceDesk.Domain.Models
{
	public class Category
	{
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

