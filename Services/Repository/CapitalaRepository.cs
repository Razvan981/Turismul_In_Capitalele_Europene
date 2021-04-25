using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Data;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.Repository
{
    public class CapitalaRepository : RepositoryBase<Capitala>, ICapitalaRepository
    {
        public CapitalaRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool CapitalaExists(int id)
        {
            var found = RepositoryContext.Capitale.Any(e => e.CapitalaId == id);
            return found;
        }
    }

}
