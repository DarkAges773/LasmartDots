using System.Collections.Generic;

namespace LasmartDots.Models
{
	public class Dot
	{
		public int Id { get; set; }
		public float PosX { get; set; }
		public float PosY { get; set; }
		public float Radius { get; set; }
		public string Color { get; set; }
		public List<Comment> Comments { get; set; } = new();
	}
}
