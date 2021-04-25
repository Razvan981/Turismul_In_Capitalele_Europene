using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Models
{
    public class Capitala
    {
        public int CapitalaId { get; set; }
        public string Denumire { get; set; }
        public string Tara { get; set; }
        public string Regiune { get; set; }
        public int Fondare_secol { get; set; }
        public int Populatie { get; set; }
        public int Suprafata_kmp { get; set; }

        public ICollection<CapitalaTurist> Turisti { get; set; }
    }
}
