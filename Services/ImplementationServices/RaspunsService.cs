using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Services.Interfaces;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class RaspunsService
    {
        private IRepositoryWrapper _repo;

        public RaspunsService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Raspuns> GetAllRaspunsuri()
        {
            return this._repo.Raspuns.FindAll();
        }
        public Raspuns GetDetailsById(int? id)
        {
            return _repo.Raspuns.FindByCondition(m => m.RaspunsId == id);
        }
        public List<Intrebare> GetAllIntrebari()
        {
            return _repo.Intrebare.FindAll();
        }
        public List<Utilizator> GetAllUtilizatori()
        {
            return _repo.Utilizator.FindAll();
        }
        public void Create(Raspuns raspuns, Utilizator utilizator)
        {
            raspuns.UtilizatorId = utilizator.Id;
            _repo.Raspuns.Create(raspuns);
            _repo.Save();
        }
        public void UpdateRaspuns(Raspuns raspuns)
        {
            _repo.Raspuns.Update(raspuns);
            _repo.Save();
        }
        public bool RaspunsExists(int id)
        {
            bool found = _repo.Raspuns.RaspunsExists(id);
            return found;
        }
        public void DeleteRaspuns(int id)
        {
            var raspuns = _repo.Raspuns.FindByCondition(m => m.RaspunsId == id);
            if (raspuns.Utilizator.Numar_Raspunsuri >= 1)
            {
                raspuns.Utilizator.Numar_Raspunsuri -= 1;
            }
            _repo.Raspuns.Delete(raspuns);

            _repo.Save();
        }
    }
}
