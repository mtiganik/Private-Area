using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyRepository : EFRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Company> All(int maxAllowed = 10)
        {
            if (!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count =  RepositoryDbSet.Count();
                if (count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(CompanyFieldOfActivity).FullName}");
                }
            }
            return RepositoryDbSet
                        .ToList();
        }

    }
}
