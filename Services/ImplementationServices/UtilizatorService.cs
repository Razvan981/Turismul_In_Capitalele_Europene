using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Services.ImplementationServices
{
    public class UtilizatorService
    {
        private IRepositoryWrapper _repo;
        private readonly UserManager<Utilizator> _userManager;
        private CapitaleEuropeneDbContext context;

        public UtilizatorService(IRepositoryWrapper repo, UserManager<Utilizator> userManager, CapitaleEuropeneDbContext context)
        {
            this._repo = repo;
            this._userManager = userManager;
            this.context = context;
        }

        public async Task<Utilizator> GetCurrentUser(ClaimsPrincipal claims)
        { 
            return await _userManager.GetUserAsync(claims); 
        }

        public async void UpdateTabelUtilizatori()
        {
            var intrebari = (from intrebare in context.Intrebari
                             from utilizator in context.Utilizatori
                             where utilizator.Id == intrebare.UtilizatorId
                             select new
                             {
                                 intrebare.UtilizatorId
                             }).ToList();

            var raspunsuri = (from raspuns in context.Raspunsuri
                              from utilizator in context.Utilizatori
                              where utilizator.Id == raspuns.UtilizatorId
                              select new
                              {
                                  raspuns.UtilizatorId
                              }).ToList();

            var utilizatoriRaspuns = (from raspuns in context.Raspunsuri
                                      from utilizator in context.Utilizatori
                                      where utilizator.Id == raspuns.UtilizatorId
                                      select new
                                      {
                                          utilizator.Id
                                      }).ToList();

            var utilizatoriIntrebare = (from intrebare in context.Intrebari
                                        from utilizator in context.Utilizatori
                                        where utilizator.Id == intrebare.UtilizatorId
                                        select new
                                        {
                                            utilizator.Id
                                        }).ToList();

            foreach (var utilizatorI in utilizatoriIntrebare)
            {
                var updateUtilizator = GetDetailsById(utilizatorI.Id);
                int nrIntrebari = 0;

                foreach (var intrebare in intrebari)
                {
                    if (utilizatorI.Id == intrebare.UtilizatorId)
                    {
                        nrIntrebari++;
                    }
                }

                updateUtilizator.Numar_Intrebari = nrIntrebari;

                UpdateUtilizator(updateUtilizator);
            }

            foreach (var utilizatorR in utilizatoriRaspuns)
            {
                var updateUtilizator = GetDetailsById(utilizatorR.Id);
                int nrRaspunsuri = 0;

                foreach (var raspuns in raspunsuri)
                {
                    if (utilizatorR.Id == raspuns.UtilizatorId)
                    {
                        nrRaspunsuri++;
                    }
                }

                updateUtilizator.Numar_Raspunsuri = nrRaspunsuri;

                UpdateUtilizator(updateUtilizator);
            }
        }

        public List<Utilizator> GetAllUtilizatori()
        {
            return _repo.Utilizator.FindAll();
        }
        public Utilizator GetDetailsById(string? id)
        {
            return _repo.Utilizator.FindByCondition(m => m.Id == id);
        }
        public void Create(Utilizator utilizator)
        {
            _repo.Utilizator.Create(utilizator);
            _repo.Save();
        }

        public void UpdateUtilizator(Utilizator utilizator)
        {
            _repo.Utilizator.Update(utilizator);
            _repo.Save();
        }
        public bool UtilizatorExists(string id)
        {
            bool found = _repo.Utilizator.UtilizatorExists(id);
            return found;
        }
        public void DeleteUtilizator(string id)
        {
            var utilizator = _repo.Utilizator.FindByCondition(m => m.Id == id);
            _repo.Utilizator.Delete(utilizator);

            _repo.Save();
        }
    }
}
