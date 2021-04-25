using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Services.Repository
{
    public class UtilizatorRepository : RepositoryBase<Utilizator>, IUtilizatorRepository
    {
        public UtilizatorRepository(CapitaleEuropeneDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public bool UtilizatorExists(string id)
        {
            var found = RepositoryContext.Utilizatori.Any(e => e.Id == id);
            return found;
        }
    }

}
