using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nutricionista.Models;

namespace Nutricionista.Data
{
    public class NutricionistaContext : DbContext
    {
        public NutricionistaContext (DbContextOptions<NutricionistaContext> options)
            : base(options)
        {
        }

        public DbSet<Nutricionista.Models.Paciente> Paciente { get; set; } = default!;
    }
}
