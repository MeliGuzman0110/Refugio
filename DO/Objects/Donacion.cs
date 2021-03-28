using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DO.Objects
{
    public class Donacion
    {
        [Key]
        public int? Iddonacion { get; set; }
        public int Iddonante { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Cantidad { get; set; }

        public virtual Donantes IddonanteNavigation { get; set; }
    }
}

