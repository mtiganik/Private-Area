using DAL.App.Interfaces.Repositories;
using DAL.EF;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.App.EF.Repositories
{
    public class TranslationRepository : EFRepository<Translation>, ITranslationRepository
    {
        public TranslationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
