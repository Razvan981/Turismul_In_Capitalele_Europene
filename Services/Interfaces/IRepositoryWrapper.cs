using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Services.Interfaces
{
    public interface IRepositoryWrapper
    {
        public ICapitalaRepository Capitala { get; }
        public ICapitalaTuristRepository CapitalaTurist { get; }
        public IIntrebareRepository Intrebare { get; }
        public INivelRepository Nivel { get; }
        public IRaspunsRepository Raspuns { get; }
        public ITuristRepository Turist { get; }
        public IUtilizatorRepository Utilizator { get; }

        public void Save();
    }
}
