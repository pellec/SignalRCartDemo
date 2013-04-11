namespace SignalRDemo.Entities
{
	public class Product : Entity
	{
		public string Title { get; set; }
		public int Available { get; set; }
		public string ImageFilePath { get; set; }
		public decimal Price { get; set; }
	}
}