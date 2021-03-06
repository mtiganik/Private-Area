﻿using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.Interfaces.Repositories
{
    public interface ICompanyFieldOfActivityRepository : IRepository<CompanyFieldOfActivity>
    {
        Task<CompanyFieldOfActivity> GetSingle(int id);

        Task<bool> ExistsByPrimaryKeyAsync(int keyValue);
    }
}
