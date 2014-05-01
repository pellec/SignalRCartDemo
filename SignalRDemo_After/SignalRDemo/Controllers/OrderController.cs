using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using SignalRDemo.Data;
using SignalRDemo.Entities;
using SignalRDemo.Hubs;

namespace SignalRDemo.Controllers
{
	public class OrderController : ApiController
	{
		private readonly IRepository<Order> _orderRepo;
		private readonly IRepository<Product> _productRepo;

		public OrderController()
			: this(new InMemoryRepository<Order>(), new InMemoryRepository<Product>())
		{
		}

		public OrderController(IRepository<Order> orderRepo, IRepository<Product> productRepo)
		{
			_orderRepo = orderRepo;
			_productRepo = productRepo;
		}

		public IHttpActionResult Get()
		{
			return Ok(_orderRepo.Get().OrderByDescending(o => o.OrderDate));
		}

		public IHttpActionResult Post(Order order)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Not cool!");
			}

			UpdateAvailability(order);

			order.OrderDate = DateTime.Now;
			order = _orderRepo.Add(order);

			GlobalHost.ConnectionManager.GetHubContext<AdminHub>().Clients.All.orderReceived(order);

			var location = new Uri(Url.Link("DefaultApi", new { id = order.Id }));

			return Created(location, order);
		}

		private void UpdateAvailability(Order order)
		{
			var cartHub = GlobalHost.ConnectionManager.GetHubContext<ShoppingCartHub>();

			int rowId = 0;
			foreach (var row in order.Rows)
			{
				row.Id = rowId;
				var product = _productRepo.Get(row.ProductId);
				if(product != null)
				{
					product.Available -= row.Quantity;
					cartHub.Clients.All.updateProductCount(product);
				}

				rowId++;
			}
		}
	}
}
