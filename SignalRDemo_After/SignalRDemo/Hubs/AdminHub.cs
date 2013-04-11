using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRDemo.Entities;

namespace SignalRDemo.Hubs
{
	[HubName("admin")]
	public class AdminHub : Hub
	{
		public void ApproveOrder(Order order)
		{

		}
	}

	[HubName("cart")]
	public class ShoppingCartHub : Hub
	{
	}
}