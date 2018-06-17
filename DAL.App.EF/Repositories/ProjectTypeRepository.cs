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
    public class ProjectTypeRepository : EFRepository<ProjectType>, IProjectTypeRepository
    {
        public ProjectTypeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<ProjectType> All(int maxAllowed = 10)
        {
            if (!(maxAllowed <= 0 || maxAllowed == int.MaxValue))
            {
                var count = RepositoryDbSet.Count(); // select count(*) from dbset
                if (count > maxAllowed)
                {
                    throw new ApplicationException($"Too many rows in result! {typeof(ProjectType).FullName} {count}/{maxAllowed}");
                }
            }
            return RepositoryDbSet
                .Include(t => t.ProjectTypeComments)
                .ThenInclude(t => t.Translations).ToList();
        }
    }
}
