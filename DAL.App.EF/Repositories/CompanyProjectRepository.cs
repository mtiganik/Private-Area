using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class CompanyProjectRepository : EFRepository<CompanyProject>, ICompanyProjectRepository
    {
        public CompanyProjectRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
