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
    public class PositionRepository : EFRepository<Position>, IPositionRepository
    {
        public PositionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Position>> GetPositionsForProject(int projectId)
        {
            return await RepositoryDbSet
                    .Where(i => i.ProjectId == projectId)
                    .Include(i => i.ApplicationUser)
                    .Include(i => i.PositionName)
                        .ThenInclude(t => t.PositionNameName)
                            .ThenInclude(t => t.Translations)
                    .Include(i => i.Project)
                    .ToListAsync();

        }
    }
}
