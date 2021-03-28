using System;
using System.Collections.Generic;

namespace APIW.Models
{
    public partial class Donacion
    {
        public int Iddonacion { get; set; }
        public int Iddonante { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Cantidad { get; set; }

        public virtual Donantes IddonanteNavigation { get; set; }
    }
}
