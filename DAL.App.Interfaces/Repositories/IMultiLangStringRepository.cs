using DAL.Interfaces.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.Interfaces.Repositories
{
    public interface IMultiLangStringRepository : IRepository<MultiLangString>
    {
        Task<MultiLangString> FindSingleAsync(int id);
    }
}
