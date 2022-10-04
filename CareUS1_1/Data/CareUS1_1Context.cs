using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CareUS1_1.Models;
using CareUS1_1.Models.CareUs.Models;

namespace CareUS1_1.Data
{
    public class CareUS1_1Context : DbContext
    {
        public CareUS1_1Context (DbContextOptions<CareUS1_1Context> options)
            : base(options)
        {
        }

        public DbSet<CareUS1_1.Models.Cliente> Cliente { get; set; } = default!;

        public DbSet<CareUS1_1.Models.Contato> Contato { get; set; }

        public DbSet<CareUS1_1.Models.Experiencia> Experiencia { get; set; }

        public DbSet<CareUS1_1.Models.CareUs.Models.Formacao> Formacao { get; set; }

        public DbSet<CareUS1_1.Models.Paciente> Paciente { get; set; }
    }
}
