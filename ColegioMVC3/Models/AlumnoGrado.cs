using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColegioMVC3.Models
{
    [Table("AlumnoGrado")]
    public class AlumnoGrado
    {
        public int AlumnoGradoId { get; set; }
        [MaxLength(32)]
        public String Seccion { get; set; }

        [Column("Alumno")]
        public int AlumnoId { get; set; }
        public virtual Alumno Alumno { get; set; }

        [Column("Grado")]
        public int GradoId { get; set; }
        public virtual Grado Grado { get; set; }

    }
}