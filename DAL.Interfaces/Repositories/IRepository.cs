using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // provide basic crud functionality
        IEnumerable<TEntity> All(int maxAllowed = 10);

        Task<IEnumerable<TEntity>> AllAsync(int maxAllowed = 10);

         // IQueryable All <-- antipattern, sql leaks out of repo

        TEntity Find(params object[] id); // Find(1) or Find(1,2,3,...)
        Task<TEntity> FindAsync(params object[] id);


        void Add(TEntity entity);
        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        void Remove(params object[] id);

    }
}
