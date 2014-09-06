using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertise.Core.Abstractions {
    public interface IRepository<T> : IDisposable where T : IEntity {
        IQueryable<T> All { get; }
        T ById(int id);
        Task<T> ByIdAsync(int id);
        void AddOrUpdate(T entity);
        void Delete(T entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
