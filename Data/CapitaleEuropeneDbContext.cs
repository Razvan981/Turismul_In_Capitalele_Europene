using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Turismul_In_Capitalele_Europene.Models;

namespace Turismul_In_Capitalele_Europene.Data
{
    public class CapitaleEuropeneDbContext : IdentityDbContext
    {
        public CapitaleEuropeneDbContext(DbContextOptions<CapitaleEuropeneDbContext> options)
            : base(options)
        {
        }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Turist> Turisti { get; set; }
        public DbSet<Capitala> Capitale { get; set; }
        public DbSet<Nivel> Nivele { get; set; }
        public DbSet<CapitalaTurist> CapitaleTuristi { get; set; }
        public DbSet<Intrebare> Intrebari { get; set; }
        public DbSet<Raspuns> Raspunsuri { get; set; }
    }
}
