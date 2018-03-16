using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces.Repositories;

namespace DAL.Interfaces.Helpers
{
    public interface IRepositoryProvider
    {
        IRepository<TEntity> ProvideEntityRepository<TEntity>()
            where TEntity : class;
        TRepositoryInterface ProvideCustomRepository<TRepositoryInterface>()
            where TRepositoryInterface : class;

    }
}
