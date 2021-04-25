using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turismul_In_Capitalele_Europene.Services.Interfaces;
using Turismul_In_Capitalele_Europene.Data;

namespace Turismul_In_Capitalele_Europene.Services.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CapitaleEuropeneDbContext _repoContext;

        private ICapitalaRepository _capitala;
        private ICapitalaTuristRepository _capitalaTurist;
        private IIntrebareRepository _intrebare;
        private INivelRepository _nivel;
        private IRaspunsRepository _raspuns;
        private ITuristRepository _turist;
        private IUtilizatorRepository _utilizator;

        public ICapitalaRepository Capitala
        {
            get
            {
                if (_capitala == null)
                {
                    _capitala = new CapitalaRepository(_repoContext);
                }

                return _capitala;
            }
        }

        public ICapitalaTuristRepository CapitalaTurist
        {
            get
            {
                if (_capitalaTurist == null)
                {
                    _capitalaTurist = new CapitalaTuristRepository(_repoContext);
                }

                return _capitalaTurist;
            }
        }

        public IIntrebareRepository Intrebare
        {
            get
            {
                if (_intrebare == null)
                {
                    _intrebare = new IntrebareRepository(_repoContext);
                }

                return _intrebare;
            }
        }

        public INivelRepository Nivel
        {
            get
            {
                if (_nivel == null)
                {
                    _nivel = new NivelRepository(_repoContext);
                }

                return _nivel;
            }
        }

        public IRaspunsRepository Raspuns
        {
            get
            {
                if (_raspuns == null)
                {
                    _raspuns = new RaspunsRepository(_repoContext);
                }

                return _raspuns;
            }
        }

        public ITuristRepository Turist
        {
            get
            {
                if (_turist == null)
                {
                    _turist = new TuristRepository(_repoContext);
                }

                return _turist;
            }
        }

        public IUtilizatorRepository Utilizator
        {
            get
            {
                if (_utilizator == null)
                {
                    _utilizator = new UtilizatorRepository(_repoContext);
                }

                return _utilizator;
            }
        }

        public RepositoryWrapper(CapitaleEuropeneDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
