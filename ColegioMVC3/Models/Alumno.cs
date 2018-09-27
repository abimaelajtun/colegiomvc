using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColegioMVC3.Models
{
    [Table("Alumno")]
    public class Alumno
    {        
        public int AlumnoId { get; set; }
        [MaxLength(128)]
        public String Nombres { get; set; }
        [MaxLength(128)]
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [MaxLength(32)]
        public String Genero { get; set; }        

        public virtual ICollection<AlumnoGrado> AlumnosGrados { get; set; }
    }

    public enum Genero
    {
        M,
        F
    }

}