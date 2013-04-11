using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using SignalRDemo.Entities;

namespace SignalRDemo.Data
{
	public class InMemoryRepository<T> : IRepository<T> where T : Entity 
	{
		private static readonly ConcurrentDictionary<int,T> Store = new ConcurrentDictionary<int,T>();

		public IEnumerable<T> Get()
		{
			return Store.Values.ToArray();
		}

		public T Add(T entity)
		{
			var id = Store.Count > 0 ? Store.Last().Key : 0;
			id++;

			entity.Id = id;

			var result = Store.TryAdd(id, entity);
			return result ? entity : null;
		}

		public T Get(int id)
		{
			T value;
			Store.TryGetValue(id, out value);
			return value;
		}
	}
}