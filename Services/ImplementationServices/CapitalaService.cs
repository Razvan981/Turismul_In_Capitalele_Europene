using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class CapitalaService
    {
        private IRepositoryWrapper _repo;
		
        public CapitalaService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Capitala> GetAllCapitals()
        {
            return _repo.Capitala.FindAll();
        }
        public Capitala GetDetailsById(int? id)
        {
            return _repo.Capitala.FindByCondition(m => m.CapitalaId == id);
        }
        public void Create(Capitala capitala)
        {
            _repo.Capitala.Create(capitala);
            _repo.Save();
        }

        public void UpdateCapitala(Capitala capitala)
        {
            _repo.Capitala.Update(capitala);
            _repo.Save();
        }
        public bool CapitalaExists(int id)
        {
            bool found = _repo.Capitala.CapitalaExists(id);
            return found;
        }
        public void DeleteCapitala(int id)
        {
            var capitala = _repo.Capitala.FindByCondition(m => m.CapitalaId == id);
            _repo.Capitala.Delete(capitala);

            _repo.Save();
        }
        public string GetDensitate(Capitala capitala)
        {
            return (capitala.Populatie / (float)capitala.Suprafata_kmp).ToString("0.0000");
        }

    }
}
