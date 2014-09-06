using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertise.Core.Abstractions {
    public interface IRepository<T> where T : IEntity {
        IQueryable<T> All { get; }
        void AddOrUpdate(T entity);
        int SaveChanges();
    }
}
