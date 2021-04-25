using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Services.Repository
{
    public class NivelRepository : RepositoryBase<Nivel>, INivelRepository
    {
        public NivelRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public bool NivelExists(int id)
        {
            var found = RepositoryContext.Nivele.Any(e => e.NivelId == id);
            return found;
        }
    }

}
