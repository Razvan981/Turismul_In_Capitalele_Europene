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
    public class RaspunsRepository : RepositoryBase<Raspuns>, IRaspunsRepository
    {
        public RaspunsRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool RaspunsExists(int id)
        {
            var found = RepositoryContext.Raspunsuri.Any(e => e.RaspunsId == id);
            return found;
        }

        public Raspuns FindByCondition(Expression<Func<Raspuns, bool>> expression)
        {
            return this.RepositoryContext.Raspunsuri
                .Include(r => r.Intrebare)
                .Include(r => r.Utilizator)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<Raspuns> FindAll()
        {
            return this.RepositoryContext.Raspunsuri
                .Include(r => r.Intrebare)
                .Include(r => r.Utilizator)
                .ToList();
        }
    }

}
