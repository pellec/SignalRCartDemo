using System.Net;
using System.Net.Http;
using System.Web.Http;
using SignalRDemo.Data;
using SignalRDemo.Entities;

namespace SignalRDemo.Controllers
{
    public class ProductController : ApiController
    {
	    private readonly IRepository<Product> _repo;

	    public ProductController() : this(new InMemoryRepository<Product>())
	    {
	    }

	    public ProductController(IRepository<Product> repo)
	    {
		    _repo = repo;
	    }

		public HttpResponseMessage Get()
		{
			return Request.CreateResponse(HttpStatusCode.OK, _repo.Get());
		}
    }
}
