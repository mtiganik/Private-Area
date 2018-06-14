using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.EF.Repositories
{
    public class CompanyFieldOfActivityRepository : EFRepository<CompanyFieldOfActivity>, ICompanyFieldOfActivityRepository
    {
        public CompanyFieldOfActivityRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async override Task<IEnumerable<CompanyFieldOfActivity>> AllAsync(int maxAllowed = 10)
        {
            if(!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count = await RepositoryDbSet.CountAsync();
                if(count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(CompanyFieldOfActivity).FullName}");
                }
            }
            return await RepositoryDbSet
                .Include(i => i.ActivityName)
                    .ThenInclude(i => i.Translations)
                        .ToListAsync() ;
        }

        public async Task<bool> ExistsByPrimaryKeyAsync(int keyValue)
        {
            return await RepositoryDbSet.AnyAsync(e => e.CompanyFieldOfActivityId == keyValue);
        }

        public async Task<CompanyFieldOfActivity> GetSingle(int id)
        {
            return await RepositoryDbSet
                .Include(i => i.ActivityName)
                    .ThenInclude(i => i.Translations)
                .SingleOrDefaultAsync(m => m.CompanyFieldOfActivityId == id);
        }

    }
}
