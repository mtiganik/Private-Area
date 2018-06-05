using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories
{
    public class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
