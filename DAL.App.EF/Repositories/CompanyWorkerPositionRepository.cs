using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyWorkerPositionRepository : EFRepository<CompanyWorkerPosition>, ICompanyWorkerPositionRepository
    {
        public CompanyWorkerPositionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
