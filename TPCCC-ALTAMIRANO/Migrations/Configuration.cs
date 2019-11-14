namespace TPCCC_ALTAMIRANO.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TPCCC_ALTAMIRANO.DAL.ReparacionesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//habilita la migracion automatica
            AutomaticMigrationDataLossAllowed = true;// habilita que se pierdan datos por tener migracion automatica, la otra forma es hacerlo manualmente
            ContextKey = "TPCCC_ALTAMIRANO.DAL.ReparacionesContext";
        }

        protected override void Seed(TPCCC_ALTAMIRANO.DAL.ReparacionesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
