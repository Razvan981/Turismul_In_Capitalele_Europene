using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Services.Repository
{
    public class TuristRepository : RepositoryBase<Turist>, ITuristRepository
    {
        public TuristRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool TuristExists(int id)
        {
            var found = RepositoryContext.Turisti.Any(e => e.TuristId == id);
            return found;
        }

        public Turist FindByCondition(Expression<Func<Turist, bool>> expression)
        {
            return this.RepositoryContext.Turisti
                .Include(t => t.Nivel)
                .Include(t => t.Utilizator)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<Turist> FindAll()
        {
            return this.RepositoryContext.Turisti
                .Include(t => t.Nivel)
                .Include(t => t.Utilizator)
                .ToList();
        }
    }

}
