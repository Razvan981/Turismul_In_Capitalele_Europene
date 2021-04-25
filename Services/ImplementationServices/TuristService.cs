using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Models;
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class TuristService
    {
        private IRepositoryWrapper _repo;
        private CapitaleEuropeneDbContext context;

        public TuristService(IRepositoryWrapper repo, CapitaleEuropeneDbContext context)
        {
            this._repo = repo;
            this.context = context;
        }

        public async void UpdateTabelTuristi()
        {
            var zilePetrecute = (from turist in context.Turisti
                                 from capitalaTurist in context.CapitaleTuristi
                                 where turist.TuristId == capitalaTurist.TuristId
                                 select new
                                 {
                                     capitalaTurist.TuristId,
                                     capitalaTurist.Zile_Petrecute
                                 }).ToList();

            var turistii = (from turist in context.Turisti
                            from capitalaTurist in context.CapitaleTuristi
                            where turist.TuristId == capitalaTurist.TuristId
                            select new
                            {
                                capitalaTurist.TuristId
                            }).ToList();

            var niveluriDenumire = (from turist in context.Turisti
                                    from nivel in context.Nivele
                                    where turist.NivelId == nivel.NivelId
                                    select new
                                    {
                                        nivel.NivelId,
                                        nivel.Punctaj_min,
                                        nivel.Punctaj_max
                                    }).ToList();


            foreach (var turist in turistii)
            {
                var updateTurist = GetDetailsById(turist.TuristId);
                int temp = 0;
                int temp2 = 0;

                foreach (var zile in zilePetrecute)
                {
                    if (turist.TuristId == zile.TuristId)
                    {
                        temp += zile.Zile_Petrecute;
                        temp2 += 1;
                    }
                }

                foreach (var denumire in niveluriDenumire)
                {
                    if (denumire.Punctaj_min <= temp && denumire.Punctaj_max >= temp)
                    {
                        updateTurist.NivelId = denumire.NivelId;
                    }
                    if (temp >= 36)
                    {
                        updateTurist.NivelId = 5;
                    }
                }

                updateTurist.Scor = temp;
                updateTurist.Locatii_Vizitate = temp2;
                UpdateTurist(updateTurist);
            }
        }

        public List<Turist> GetAllTurist()
        {
            return this._repo.Turist.FindAll();
        }
        public Turist GetDetailsById(int? id)
        {
            return _repo.Turist.FindByCondition(m => m.TuristId == id);
        }
        public List<Nivel> GetAllNivele()
        {
            return _repo.Nivel.FindAll();
        }
        public List<Utilizator> GetAllUtilizatori()
        {
            return _repo.Utilizator.FindAll();
        }
        public void Create(Turist turist)
        {
            _repo.Turist.Create(turist);
            _repo.Save();
        }
        public void UpdateTurist(Turist turist)
        {
            _repo.Turist.Update(turist);
            _repo.Save();
        }
        public bool TuristExists(int id)
        {
            bool found = _repo.Turist.TuristExists(id);
            return found;
        }
        public void DeleteTurist(int id)
        {
            var turist = _repo.Turist.FindByCondition(m => m.TuristId == id);
            _repo.Turist.Delete(turist);

            _repo.Save();
        }
    }
}
