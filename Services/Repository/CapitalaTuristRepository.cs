using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Data;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.Repository
{
    public class CapitalaTuristRepository : RepositoryBase<CapitalaTurist>, ICapitalaTuristRepository
    {
        public CapitalaTuristRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool CapitalaTuristExists(int id)
        {
            var found = RepositoryContext.CapitaleTuristi.Any(e => e.CapitalaTuristId == id);
            return found;
        }

        public CapitalaTurist FindByCondition(Expression<Func<CapitalaTurist, bool>> expression)
        {
            return this.RepositoryContext.CapitaleTuristi
                .Include(c => c.Capitala)
                .Include(c => c.Turist)
                .Include(c => c.Turist.Utilizator)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<CapitalaTurist> FindAll()
        {
            return this.RepositoryContext.CapitaleTuristi
                .Include(c => c.Capitala)
                .Include(c => c.Turist)
                .Include(c => c.Turist.Utilizator)
                .ToList();

        }
    }

}
