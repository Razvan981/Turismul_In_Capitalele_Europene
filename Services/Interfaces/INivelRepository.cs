using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.Interfaces
{
    public interface INivelRepository : IRepositoryBase<Nivel>
    {
        public bool NivelExists(int id);
    }
}
