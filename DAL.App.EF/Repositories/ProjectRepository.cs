using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class ProjectRepository : EFRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DbContext dbContext) : base(dbContext)
        {
        }


        public async override Task<IEnumerable<Project>> AllAsync(int maxAllowed = 10)
        {
            if (!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count = await RepositoryDbSet.CountAsync();
                if (count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(Project).FullName}");
                }
            }

            return await RepositoryDbSet
                .Include(i => i.ProjectType)
                .Include(i => i.Positions)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.Positions)
                    .ThenInclude(i => i.PositionName)
                .AsNoTracking()
                .OrderBy(i => i.ProjectStartDate)
                .ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await RepositoryDbSet
                .Where(i => i.ProjectId == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Project> GetSingleWithProjectType(int id)
        {
            return await RepositoryDbSet
                .Include(p => p.ProjectType)
                .SingleOrDefaultAsync(m => m.ProjectId == id);
        }
        public async Task<Project> GetSingleEnhancedAsync(int id)
        {
            return await RepositoryDbSet
                .Where(u => u.ProjectId == id)
                .Include(i => i.Positions)
                    .ThenInclude(i => i.PositionName)
                        .ThenInclude(i => i.PositionNameName)
                            .ThenInclude(i => i.Translations)
                .Include(i => i.Positions)
                    .ThenInclude(i => i.ApplicationUser)
                .Include(i => i.ProjectType)
                .Include(i => i.CompanyProjects)
                    .ThenInclude(i => i.Company)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> ExistsByPrimaryKeyAsync(int keyValue)
        {
            return await RepositoryDbSet.AnyAsync(e => e.ProjectTypeId == keyValue);
        }


    }
}
