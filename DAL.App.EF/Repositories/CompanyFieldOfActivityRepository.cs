using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class CompanyFieldOfActivityRepository : EFRepository<CompanyFieldOfActivity>, ICompanyFieldOfActivityRepository
    {
        public CompanyFieldOfActivityRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
