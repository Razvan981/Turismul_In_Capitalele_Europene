using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Models
{
    public class Intrebare
    {
        public int IntrebareId { get; set; }

        [ForeignKey("Utilizator")]
        public string UtilizatorId { get; set; }
        public DateTime Data { get; set; }
        public string Continut { get; set; }

        public Utilizator Utilizator { get; set; }
        public ICollection<Raspuns> Raspunsuri { get; set; }
    }
}
