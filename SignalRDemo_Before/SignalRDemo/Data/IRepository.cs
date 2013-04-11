using System.Collections.Generic;
using SignalRDemo.Entities;

namespace SignalRDemo.Data
{
	public interface IRepository<T> where T: Entity
	{
		IEnumerable<T> Get();
		T Add(T entity);
		T Get(int id);
	}
}