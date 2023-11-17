using System;
namespace ServiceDesk.Domain.Models
{
	public class Task
	{
        public Guid Id { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid UserAssignedId { get; set; }
        public User? UserAssigned { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime FinishLimitResponse { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

