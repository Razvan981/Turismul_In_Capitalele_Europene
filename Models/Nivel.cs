using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Models
{
    public class Nivel
    {
        public int NivelId { get; set; }
        public string Denumire { get; set; }
        public int Punctaj_min { get; set; }
        public int Punctaj_max { get; set; }

        public ICollection<Turist> Turisti { get; set; }
    }
}
