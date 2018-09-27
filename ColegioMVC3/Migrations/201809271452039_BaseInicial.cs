namespace ColegioMVC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        AlumnoId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Genero = c.String(),
                    })
                .PrimaryKey(t => t.AlumnoId);
            
            CreateTable(
                "dbo.AlumnoGrado",
                c => new
                    {
                        AlumnoGradoId = c.Int(nullable: false, identity: true),
                        Seccion = c.String(),
                        AlumnoId = c.Int(nullable: false),
                        GradoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlumnoGradoId)
                .ForeignKey("dbo.Alumno", t => t.AlumnoId, cascadeDelete: true)
                .ForeignKey("dbo.Grado", t => t.GradoId, cascadeDelete: true)
                .Index(t => t.AlumnoId)
                .Index(t => t.GradoId);
            
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        GradoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ProfesorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GradoId)
                .ForeignKey("dbo.Profesor", t => t.ProfesorId, cascadeDelete: true)
                .Index(t => t.ProfesorId);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Genero = c.String(),
                    })
                .PrimaryKey(t => t.ProfesorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grado", "ProfesorId", "dbo.Profesor");
            DropForeignKey("dbo.AlumnoGrado", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.AlumnoGrado", "AlumnoId", "dbo.Alumno");
            DropIndex("dbo.Grado", new[] { "ProfesorId" });
            DropIndex("dbo.AlumnoGrado", new[] { "GradoId" });
            DropIndex("dbo.AlumnoGrado", new[] { "AlumnoId" });
            DropTable("dbo.Profesor");
            DropTable("dbo.Grado");
            DropTable("dbo.AlumnoGrado");
            DropTable("dbo.Alumno");
        }
    }
}
