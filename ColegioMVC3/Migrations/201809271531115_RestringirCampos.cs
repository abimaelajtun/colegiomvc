namespace ColegioMVC3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestringirCampos : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AlumnoGrado", name: "AlumnoId", newName: "Alumno");
            RenameColumn(table: "dbo.AlumnoGrado", name: "GradoId", newName: "Grado");
            RenameColumn(table: "dbo.Grado", name: "ProfesorId", newName: "Profesor");
            RenameIndex(table: "dbo.AlumnoGrado", name: "IX_AlumnoId", newName: "IX_Alumno");
            RenameIndex(table: "dbo.AlumnoGrado", name: "IX_GradoId", newName: "IX_Grado");
            RenameIndex(table: "dbo.Grado", name: "IX_ProfesorId", newName: "IX_Profesor");
            AlterColumn("dbo.Alumno", "Nombres", c => c.String(maxLength: 128));
            AlterColumn("dbo.Alumno", "Apellidos", c => c.String(maxLength: 128));
            AlterColumn("dbo.Alumno", "Genero", c => c.String(maxLength: 32));
            AlterColumn("dbo.AlumnoGrado", "Seccion", c => c.String(maxLength: 32));
            AlterColumn("dbo.Grado", "Nombre", c => c.String(maxLength: 128));
            AlterColumn("dbo.Profesor", "Nombres", c => c.String(maxLength: 128));
            AlterColumn("dbo.Profesor", "Apellidos", c => c.String(maxLength: 128));
            AlterColumn("dbo.Profesor", "Genero", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profesor", "Genero", c => c.String());
            AlterColumn("dbo.Profesor", "Apellidos", c => c.String());
            AlterColumn("dbo.Profesor", "Nombres", c => c.String());
            AlterColumn("dbo.Grado", "Nombre", c => c.String());
            AlterColumn("dbo.AlumnoGrado", "Seccion", c => c.String());
            AlterColumn("dbo.Alumno", "Genero", c => c.String());
            AlterColumn("dbo.Alumno", "Apellidos", c => c.String());
            AlterColumn("dbo.Alumno", "Nombres", c => c.String());
            RenameIndex(table: "dbo.Grado", name: "IX_Profesor", newName: "IX_ProfesorId");
            RenameIndex(table: "dbo.AlumnoGrado", name: "IX_Grado", newName: "IX_GradoId");
            RenameIndex(table: "dbo.AlumnoGrado", name: "IX_Alumno", newName: "IX_AlumnoId");
            RenameColumn(table: "dbo.Grado", name: "Profesor", newName: "ProfesorId");
            RenameColumn(table: "dbo.AlumnoGrado", name: "Grado", newName: "GradoId");
            RenameColumn(table: "dbo.AlumnoGrado", name: "Alumno", newName: "AlumnoId");
        }
    }
}
