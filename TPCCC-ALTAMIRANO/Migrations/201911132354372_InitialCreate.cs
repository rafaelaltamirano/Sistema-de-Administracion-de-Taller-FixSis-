namespace TPCCC_ALTAMIRANO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Cuit = c.Long(nullable: false),
                        Direccion = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Repuesto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Marca_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marca", t => t.Marca_ID)
                .Index(t => t.Marca_ID);
            
            CreateTable(
                "dbo.Servicio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Costo = c.String(),
                        Repuesto_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Repuesto", t => t.Repuesto_Id)
                .Index(t => t.Repuesto_Id);
            
            CreateTable(
                "dbo.Sucursal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Direccion = c.String(),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Alias = c.String(),
                        TipoUsuario = c.Int(nullable: false),
                        Dni = c.Int(nullable: false),
                        Pass = c.String(),
                        IdSucursal = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicio", "Repuesto_Id", "dbo.Repuesto");
            DropForeignKey("dbo.Repuesto", "Marca_ID", "dbo.Marca");
            DropIndex("dbo.Servicio", new[] { "Repuesto_Id" });
            DropIndex("dbo.Repuesto", new[] { "Marca_ID" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Sucursal");
            DropTable("dbo.Servicio");
            DropTable("dbo.Repuesto");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Marca");
        }
    }
}
