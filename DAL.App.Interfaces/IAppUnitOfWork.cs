using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        // Could Be done like this aswell
        // ICompanyFieldOfActivityRepository CompanyFieldOfActivity { get; set; }
        IRepository<ApplicationUser> ApplicationUsers { get; }
        IRepository<Company> Companies { get;  }
        IRepository<CompanyFieldOfActivity> CompanyFieldOfActivities{ get; }
        IRepository<CompanyType> CompanyTypes { get; }
        IRepository<CompanyWorker> CompanyWorkers { get;  }
        IRepository<CompanyWorkerPosition> CompanyWorkerPositions { get; }
        IRepository<Contact> Contacts { get;  }
        IRepository<ContactType> ContactTypes { get; }
        IRepository<Position> Positions { get; }
        IRepository<PositionName> PositionNames { get; }
        IRepository<Project> Projects { get; }
        IRepository<ProjectType> ProjectTypes { get; }
        IRepository<Department> Departments { get; }
        IRepository<UserStatus> UserStatuses { get; }


        

    }
}
