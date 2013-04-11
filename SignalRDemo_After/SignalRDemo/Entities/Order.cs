using System;
using System.Linq;

namespace SignalRDemo.Entities
{
	public class Order : Entity
	{
		public DateTime OrderDate { get; set; }
		public string CustomerId { get; set; }
		public OrderRow[] Rows { get; set; }
		public int TotalQuantity { get { return Rows.Sum(r => r.Quantity); } }
		public decimal TotalAmount { get { return Rows.Sum(r => r.SubTotal); }}
	}

	public class OrderRow : Entity
	{
		public int ProductId { get; set; }
		public int Quantity { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
		public decimal SubTotal { get { return Quantity*Price; } }
	}
}