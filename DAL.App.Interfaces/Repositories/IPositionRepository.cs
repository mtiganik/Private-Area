using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;
using Domain;


namespace DAL.App.Interfaces.Repositories
{
    public interface IPositionRepository : IRepository<Position>
    {
        Task<IEnumerable<Position>> GetPositionsForProject(int projectId);
    }
}
