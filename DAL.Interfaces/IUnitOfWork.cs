using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task SaveChangesAsync();

        IRepository<TEntity> GetEntityRepository<TEntity>() 
            where TEntity : class;
        TRepositoryInterface GetCustomRepository<TRepositoryInterface>() 
            where TRepositoryInterface : class;
    }
}
