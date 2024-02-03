using System;
namespace TODoUsingAPI.Models
{
	public class Todo
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public bool IsFinish { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}

