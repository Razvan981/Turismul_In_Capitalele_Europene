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
    public class IntrebareRepository : RepositoryBase<Intrebare>, IIntrebareRepository
    {
        public IntrebareRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool IntrebareExists(int id)
        {
            var found = RepositoryContext.Intrebari.Any(e => e.IntrebareId == id);
            return found;
        }

        public Intrebare FindByCondition(Expression<Func<Intrebare, bool>> expression)
        {
            return this.RepositoryContext.Intrebari
                .Include(i => i.Utilizator)
                .Where(expression)
                .FirstOrDefault();
        }

        public List<Intrebare> FindAll()
        {
            return this.RepositoryContext.Intrebari
                .Include(i => i.Utilizator)
                .ToList();

        }
    }

}
