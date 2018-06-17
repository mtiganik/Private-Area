using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.App.EF.Repositories;
using DAL.App.Interfaces;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.EF
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IRepositoryProvider _repositoryProvider;

        public AppUnitOfWork(IDataContext dbContext, IRepositoryProvider repositoryProvider)
        {
            _dbContext = dbContext as ApplicationDbContext;
            if (_dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            _repositoryProvider = repositoryProvider;
        }

        // You could do it like this aswell:
        //public IRepository<CompanyFieldOfActivity> CompanyFieldOfActivities =>
        //    GetEntityRepository<CompanyFieldOfActivity>();

        public ICompanyFieldOfActivityRepository CompanyFieldOfActivities =>
            GetCustomRepository<ICompanyFieldOfActivityRepository>();

        public IApplicationUserRepository ApplicationUsers =>
            GetCustomRepository<IApplicationUserRepository>();

        public ICompanyRepository Companies =>
            GetCustomRepository<ICompanyRepository>();

        public ICompanyProjectRepository CompanyProjects =>
            GetCustomRepository<ICompanyProjectRepository>();


        public ICompanyTypeRepository CompanyTypes =>
            GetCustomRepository<ICompanyTypeRepository>();


        public ICompanyWorkerRepository CompanyWorkers =>
            GetCustomRepository<ICompanyWorkerRepository>();


        public ICompanyWorkerPositionRepository CompanyWorkerPositions =>
            GetCustomRepository<ICompanyWorkerPositionRepository>();


        public IContactRepository Contacts =>
            GetCustomRepository<IContactRepository>();


        public IContactTypeRepository ContactTypes =>
            GetCustomRepository<IContactTypeRepository>();

        public IMultiLangStringRepository MultiLangStrings =>
             GetCustomRepository<IMultiLangStringRepository>();



        public IPositionRepository Positions =>
            GetCustomRepository<IPositionRepository>();


        public IPositionNameRepository PositionNames =>
            GetCustomRepository<IPositionNameRepository>();


        public IProjectRepository Projects =>
            GetCustomRepository<IProjectRepository>();


        public IProjectTypeRepository ProjectTypes =>
            GetCustomRepository<IProjectTypeRepository>();

        public ITranslationRepository Translations =>
            GetCustomRepository<ITranslationRepository>();

        public IDepartmentRepository Departments =>
            GetCustomRepository<IDepartmentRepository>();


        public IUserStatusRepository UserStatuses =>
            GetCustomRepository<IUserStatusRepository>();



        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IRepository<TEntity> GetEntityRepository<TEntity>() where TEntity : class
        {
            return _repositoryProvider
                .ProvideEntityRepository<TEntity>();
        }

        public TRepositoryInterface GetCustomRepository<TRepositoryInterface>() where TRepositoryInterface : class
        {
            return _repositoryProvider
                .ProvideCustomRepository<TRepositoryInterface>();
        }

    }
}
