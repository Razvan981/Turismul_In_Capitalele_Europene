using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Models
{
    public class CapitalaTurist
    {
        public int CapitalaTuristId { get; set; }
        public int CapitalaId { get; set; }
        public int TuristId { get; set; }
        public int Zile_Petrecute { get; set; }
        public int Calificativ_Acordat { get; set; }

        public Capitala Capitala { get; set; }
        public Turist Turist { get; set; }

    }
}
