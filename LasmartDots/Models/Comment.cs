using System.Text.Json.Serialization;

namespace LasmartDots.Models
{
	public class Comment
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public string? BackgroundColor { get; set; }

		public int DotId { get; set; }
		[JsonIgnore]
		public Dot? Dot { get; set; }
	}
}
