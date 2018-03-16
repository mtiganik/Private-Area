using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;

        public EFRepository(DbContext dbContext)
        {

            RepositoryDbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> All(int maxAllowed = 10)
        {
            if (!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count = RepositoryDbSet.Count(); // select count(*) from dbset
                if (count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(TEntity).FullName} {count}/{maxAllowed}");
                }

            }

            var res = RepositoryDbSet.ToList();

            return res;
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync(int maxAllowed = 10)
        {
            if (!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count = await RepositoryDbSet.CountAsync(); // select count(*) from dbset
                if (count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(TEntity).FullName} {count}/{maxAllowed}");
                }

            }
            return await RepositoryDbSet.ToListAsync();
        }

        public virtual void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await RepositoryDbSet.AddAsync(entity);
        }


        public virtual TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }

        public virtual void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public virtual void Remove(params Object[] id)
        {
            Remove(Find(id));
        }

        public virtual async Task<TEntity> FindAsync(params Object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        public virtual TEntity Find(params Object[] id)
        {
            return RepositoryDbSet.Find(id);
        }
    }
}
