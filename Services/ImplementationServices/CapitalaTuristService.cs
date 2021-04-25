using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class CapitalaTuristService
    {
        private IRepositoryWrapper _repo;

        public CapitalaTuristService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<CapitalaTurist> GetAllCapitalaTurist()
        {
            return this._repo.CapitalaTurist.FindAll();
        }
        public CapitalaTurist GetDetailsById(int? id)
        {
            return _repo.CapitalaTurist.FindByCondition(m => m.CapitalaTuristId == id);
        }
        public List<Capitala> GetAllCapitala()
        {
            return _repo.Capitala.FindAll();
        }
        public List<Turist> GetAllTuristi()
        {
            return _repo.Turist.FindAll();
        }
        public void Create(CapitalaTurist capitalaTurist)
        {
            _repo.CapitalaTurist.Create(capitalaTurist);
            _repo.Save();
        }
        public void UpdateCapitalaTurist(CapitalaTurist capitalaTurist)
        {
            _repo.CapitalaTurist.Update(capitalaTurist);
            _repo.Save();
        }
        public bool CapitalaTuristExists(int id)
        {
            bool found = _repo.CapitalaTurist.CapitalaTuristExists(id);
            return found;
        }
        public void DeleteCapitalaTurist(int id)
        {
            var capitalaTurist = _repo.CapitalaTurist.FindByCondition(m => m.CapitalaTuristId == id);
            _repo.CapitalaTurist.Delete(capitalaTurist);

            _repo.Save();
        }
    }
}
