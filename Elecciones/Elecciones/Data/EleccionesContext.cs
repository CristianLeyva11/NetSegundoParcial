using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elecciones.Models;

namespace Elecciones.Data
{
    public class EleccionesContext : DbContext
    {
        public EleccionesContext (DbContextOptions<EleccionesContext> options)
            : base(options)
        {
        }

        public DbSet<Elecciones.Models.Candidatos> Candidatos { get; set; } = default!;
    }
}
