using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _2019LM606WACRUD.Models
{
    public class tipoEquipo
    {
        [Key]
        public int id_tipo_equipo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
    }
}
