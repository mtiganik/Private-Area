using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces.Helpers
{
    public interface IRepositoryFactoryProvider
    {
        Func<IDataContext, object> GetFactoryForStandarRepo<TEntity>() where TEntity : class;

        Func<IDataContext, object> GetFactoryForCustomRepo<TRepositoryInterface>()
            where TRepositoryInterface : class;

    }
}
