using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SignalRDemo.Data;
using SignalRDemo.Entities;

namespace SignalRDemo
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterSignalrJsonSerializer();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			new InMemoryRepository<Product>().Add(new Product { Available = 10, Title = "Snuten i Hollywood I", ImageFilePath = "Content/images/snuten_i_hollywood_i.jpg", Price = 99m});
			new InMemoryRepository<Product>().Add(new Product { Available = 30, Title = "Snuten i Hollywood II", ImageFilePath = "Content/images/snuten_i_hollywood_ii.jpg", Price = 199m });
			new InMemoryRepository<Product>().Add(new Product { Available = 66, Title = "Snuten i Hollywood III", ImageFilePath = "Content/images/snuten_i_hollywood_iii.jpg", Price = 49m });
			new InMemoryRepository<Product>().Add(new Product { Available = 78, Title = "Snuten i Hollywood IV", ImageFilePath = "Content/images/snuten_i_hollywood_iv.jpg", Price = 69m });
		}

		private static void RegisterSignalrJsonSerializer()
		{
			var settings = new JsonSerializerSettings
			{
				ContractResolver = new SignalRContractResolver()
			};

			var serializer = JsonSerializer.Create(settings);
			GlobalHost.DependencyResolver.Register(typeof (JsonSerializer), () => serializer);
		}
	}
}