using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain;


namespace DAL.App.Interfaces.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetSingle(int id);
        Task<Project> GetSingleWithProjectType(int id);
        Task<bool> ExistsByPrimaryKeyAsync(int keyValue);
        Task<Project> GetSingleEnhancedAsync(int id);
    }
}
