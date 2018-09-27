using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColegioMVC3.Models
{
    [Table("Grado")]
    public class Grado
    {
        public int GradoId { get; set; }
        [MaxLength(128)]
        public String Nombre { get; set; }

        [Display(Name = "Profesor")]
        [Column("Profesor")]
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<AlumnoGrado> AlumnosGrados { get; set; }
    }
}