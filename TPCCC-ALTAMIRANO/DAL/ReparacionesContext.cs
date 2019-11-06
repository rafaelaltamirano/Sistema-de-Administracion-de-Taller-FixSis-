using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TPCCC_ALTAMIRANO.Models;

namespace TPCCC_ALTAMIRANO.DAL
{
    public class ReparacionesContext : DbContext// inda cuales seran las tablas que se van a generar desde nuestra app
    {
        public ReparacionesContext()
                :base("DefaultConnection")
          {

          }

        
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Servicio> Servicio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

      

        
    }
}