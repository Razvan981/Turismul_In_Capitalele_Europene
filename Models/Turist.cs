using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Models
{
    public class Turist
    {
        public int TuristId { get; set; }

        [ForeignKey("Utilizator")]
        public string UtilizatorId { get; set; }
        public int NivelId { get; set; }
        public int Locatii_Vizitate { get; set; }
        public int Scor { get; set; }

        public ICollection<CapitalaTurist> CapitaleVizitate { get; set; }
        public Utilizator Utilizator { get; set; }
        public Nivel Nivel { get; set; }
    }
}
