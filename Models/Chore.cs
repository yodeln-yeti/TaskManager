using System;
namespace TaskManager.Models
{
	public class Chore
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime Deadline { get; set; }
		public bool IsCompleted { get; set; }
	}
}

