using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Triaje.Models;
using Triaje.Models.TriajeGeneral;

namespace Triaje.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Signo> Signos { get; set; }
        public DbSet<TipoSigno> TipoSignos { get; set; }
        public DbSet<TipoPrioridad> TiposPrioridades { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<ConsultaPediatria> Pediatrias { get; set; }
        public DbSet<ConsultaObstetrica> Obstetricas { get; set; }
    }
}
