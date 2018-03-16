using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;

namespace DAL.App.EF.Helpers
{
    public class EFRepositoryFactoryProvider : IRepositoryFactoryProvider
    {
        private static readonly Dictionary<Type, Func<IDataContext, object>> _customRepositoryFactories = GetCustomRepoFactories();

        public Func<IDataContext, object> GetFactoryForStandarRepo<TEntity>() where TEntity : class
        {
            return (context) => new EFRepository<TEntity>(context as ApplicationDbContext);
        }

        public Func<IDataContext, object> GetFactoryForCustomRepo<TRepositoryInterface>() where TRepositoryInterface : class
        {

            _customRepositoryFactories.TryGetValue(typeof(TRepositoryInterface), out var factory);
            return factory;
        }

        private static Dictionary<Type, Func<IDataContext, object>> GetCustomRepoFactories()
        {
            return new Dictionary<Type, Func<IDataContext, object>>()
            {
                { typeof(IApplicationUserRepository), (dataContext) =>  new ApplicationUserRepository(dataContext as ApplicationDbContext)},
                { typeof(ICompanyFieldOfActivityRepository), (dataContext) =>  new CompanyFieldOfActivityRepository(dataContext as ApplicationDbContext)},
                { typeof(ICompanyRepository), (dataContext) =>  new CompanyRepository(dataContext as ApplicationDbContext)},
                { typeof(ICompanyTypeRepository), (dataContext) =>  new CompanyTypeRepository(dataContext as ApplicationDbContext)},
                { typeof(ICompanyWorkerRepository), (dataContext) =>  new CompanyWorkerRepository(dataContext as ApplicationDbContext)},
                { typeof(ICompanyWorkerPositionRepository), (dataContext) =>  new CompanyWorkerPositionRepository(dataContext as ApplicationDbContext)},
                { typeof(IContactRepository), (dataContext) =>  new ContactRepository(dataContext as ApplicationDbContext)},
                { typeof(IContactTypeRepository), (dataContext) =>  new ContactTypeRepository(dataContext as ApplicationDbContext)},
                { typeof(IPositionNameRepository), (dataContext) =>  new PositionNameRepository(dataContext as ApplicationDbContext)},
                { typeof(IPositionRepository), (dataContext) =>  new PositionRepository(dataContext as ApplicationDbContext)},
                { typeof(IProjectRepository), (dataContext) =>  new ProjectRepository(dataContext as ApplicationDbContext)},
                { typeof(IProjectTypeRepository), (dataContext) =>  new ProjectTypeRepository(dataContext as ApplicationDbContext)},
                { typeof(ISpecialityRepository), (dataContext) =>  new SpecialityRepository(dataContext as ApplicationDbContext)},
                { typeof(IUserStatusRepository), (dataContext) =>  new UserStatusRepository(dataContext as ApplicationDbContext)},

                //{ typeof(IPersonRepository), (dataContext) =>  new PersonRepository(dataContext as ApplicationDbContext)},
                //{ typeof(IContactRepository), (dataContext) =>  new ContactRepository(dataContext as ApplicationDbContext)},
                //{ typeof(IContactTypeRepository), (dataContext) =>  new ContactTypeRepository(dataContext as ApplicationDbContext)}
            };
        }

    }
}
