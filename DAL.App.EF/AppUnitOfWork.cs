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
        //public ICompanyFieldOfActivityRepository CompanyFieldOfActivities =>
        //    GetCustomRepository<ICompanyFieldOfActivityRepository>();

        public IRepository<CompanyFieldOfActivity> CompanyFieldOfActivities =>
            GetEntityRepository<CompanyFieldOfActivity>();

        public IRepository<ApplicationUser> ApplicationUsers =>
            GetEntityRepository<ApplicationUser>();

        public IRepository<Company> Companies =>
            GetEntityRepository<Company>();


        public IRepository<CompanyType> CompanyTypes =>
            GetEntityRepository<CompanyType>();


        public IRepository<CompanyWorker> CompanyWorkers =>
            GetEntityRepository<CompanyWorker>();


        public IRepository<CompanyWorkerPosition> CompanyWorkerPositions =>
            GetEntityRepository<CompanyWorkerPosition>();


        public IRepository<Contact> Contacts =>
            GetEntityRepository<Contact>();


        public IRepository<ContactType> ContactTypes =>
            GetEntityRepository<ContactType>();


        public IRepository<Position> Positions =>
            GetEntityRepository<Position>();


        public IRepository<PositionName> PositionNames =>
            GetEntityRepository<PositionName>();


        public IRepository<Project> Projects =>
            GetEntityRepository<Project>();


        public IRepository<ProjectType> ProjectTypes =>
            GetEntityRepository<ProjectType>();


        public IRepository<Department> Departments =>
            GetEntityRepository<Department>();


        public IRepository<UserStatus> UserStatuses =>
            GetEntityRepository<UserStatus>();



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
