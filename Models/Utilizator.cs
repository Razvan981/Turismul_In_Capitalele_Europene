using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turismul_In_Capitalele_Europene.Models
{
    public class Utilizator : IdentityUser
    {

        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Numar_Intrebari { get; set; }
        public int Numar_Raspunsuri { get; set; }
        public byte[] Imagine { get; set; }

        public Turist Turist { get; set; }
        public ICollection<Intrebare> Intrebari { get; set; }
        public ICollection<Raspuns> Raspunsuri { get; set; }
    }
}
