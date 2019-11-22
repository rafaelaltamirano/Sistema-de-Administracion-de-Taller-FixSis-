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
        public DbSet<Repuesto> Repuesto { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        //public DbSet<Ingreso> Login { get; set; }
        //public DbSet<Cliente> Cliente { get; set; }
        public object ObjectStateManager { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<TPCCC_ALTAMIRANO.Models.Cliente> Cliente { get; set; }

        
    }
}