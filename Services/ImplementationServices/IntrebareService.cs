using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Services.Interfaces;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class IntrebareService
    {
        private IRepositoryWrapper _repo;

        public IntrebareService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Intrebare> GetAllIntrebari()
        {
            return this._repo.Intrebare.FindAll();
        }
        public Intrebare GetDetailsById(int? id)
        {
            return _repo.Intrebare.FindByCondition(m => m.IntrebareId == id);
        }
        public List<Utilizator> GetAllUtilizatori()
        {
            return _repo.Utilizator.FindAll();
        }
        public void Create(Intrebare intrebare, Utilizator utilizator)
        {
            intrebare.UtilizatorId = utilizator.Id;
            _repo.Intrebare.Create(intrebare);
            _repo.Save();
        }

        public void UpdateIntrebare(Intrebare intrebare)
        {
            _repo.Intrebare.Update(intrebare);
            _repo.Save();
        }
        public bool IntrebareExists(int id)
        {
            bool found = _repo.Intrebare.IntrebareExists(id);
            return found;
        }
        public void DeleteIntrebare(int id)
        {
            var intrebare = _repo.Intrebare.FindByCondition(m => m.IntrebareId == id);
            if(intrebare.Utilizator.Numar_Intrebari >= 1)
            {
                intrebare.Utilizator.Numar_Intrebari -= 1;
            }
            _repo.Intrebare.Delete(intrebare);

            _repo.Save();
        }
    }
}
