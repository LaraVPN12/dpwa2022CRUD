using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _2019LM606WACRUD.Models;

namespace _2019LM606WACRUD
{
    public class prestamosContext : DbContext
    {
        public prestamosContext(DbContextOptions<prestamosContext> options) : base(options)
        {

        }
        public DbSet<equipos> equipos { get; set; }
        public DbSet<estadoEquipos> estado_equipos { get; set; }
        public DbSet<marcas> _marca { get; set; }
        public DbSet<tipoEquipo> _tipo { get; set; }
    }
}
