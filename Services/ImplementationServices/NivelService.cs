using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class NivelService
    {
        private IRepositoryWrapper _repo;

        public NivelService(IRepositoryWrapper repo)
        {
            this._repo = repo;
        }
        public List<Nivel> GetAllNivels()
        {
            return _repo.Nivel.FindAll();
        }
        public Nivel GetDetailsById(int? id)
        {
            return _repo.Nivel.FindByCondition(m => m.NivelId == id);
        }
        public void Create(Nivel nivel)
        {
            _repo.Nivel.Create(nivel);
            _repo.Save();
        }

        public void UpdateNivel(Nivel nivel)
        {
            _repo.Nivel.Update(nivel);
            _repo.Save();
        }
        public bool NivelExists(int id)
        {
            bool found = _repo.Nivel.NivelExists(id);
            return found;
        }
        public void DeleteNivel(int id)
        {
            var nivel = _repo.Nivel.FindByCondition(m => m.NivelId == id);
            _repo.Nivel.Delete(nivel);

            _repo.Save();
        }
    }
}
