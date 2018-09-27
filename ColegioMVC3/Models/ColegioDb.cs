using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ColegioMVC3.Models
{
    public class ColegioDb : DbContext
    {
        public ColegioDb() : base("ColegioDb")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<AlumnoGrado> AlumnosGrados { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}