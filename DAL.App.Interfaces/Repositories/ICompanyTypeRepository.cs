using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain;


namespace DAL.App.Interfaces.Repositories
{
    public interface ICompanyTypeRepository : IRepository<CompanyType>
    {
        Task<CompanyType> GetSingle(int id);

        Task<bool> ExistsByPrimaryKeyAsync(int keyValue);

    }
}
