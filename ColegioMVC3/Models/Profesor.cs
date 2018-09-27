using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ColegioMVC3.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        public int ProfesorId { get; set; }
        [MaxLength(128)]        
        public String Nombres { get; set; }
        [MaxLength(128)]
        public String Apellidos { get; set; }
        [MaxLength(32)]
        public String Genero { get; set; }        

        public virtual ICollection<Grado> Grados { get; set; }
    }
}