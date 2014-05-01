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

		public IHttpActionResult Get()
		{
			return Ok(_repo.Get());
		}
    }
}
