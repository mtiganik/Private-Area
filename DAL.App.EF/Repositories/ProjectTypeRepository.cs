using System;
using System.Collections.Generic;
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
    }
}
