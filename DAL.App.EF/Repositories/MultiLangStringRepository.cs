using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.App.EF.Repositories
{
    public class MultiLangStringRepository : EFRepository<MultiLangString>, IMultiLangStringRepository
    {
        public MultiLangStringRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<MultiLangString> FindSingleAsync(int id)
        {
            return await RepositoryDbSet
                .Include(t => t.Translations)
                .FirstOrDefaultAsync(m => m.MultiLangStringId == id);
        }
    }
}
