using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class CompanyTypeRepository : EFRepository<CompanyType>, ICompanyTypeRepository
    {
        public CompanyTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<CompanyType>> AllAsync(int maxAllowed = 10)
        {
            if (!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count = await RepositoryDbSet.CountAsync();
                if (count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(CompanyType).FullName}");
                }
            }


            return await RepositoryDbSet
                .Include(t => t.CompanyTypeName)
                    .ThenInclude(t => t.Translations)
                        .ToListAsync();
        }

        public async Task<CompanyType> GetSingle(int id)
        {
            return await RepositoryDbSet
                .Include(t => t.CompanyTypeName)
                    .ThenInclude(t => t.Translations)
                .SingleOrDefaultAsync(m => m.CompanyTypeId == id);
        }

        public async Task<bool> ExistsByPrimaryKeyAsync(int keyValue)
        {
            return await RepositoryDbSet.AnyAsync(e => e.CompanyTypeId == keyValue);
        }



    }
}
