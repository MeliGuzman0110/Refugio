using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefugioAnimal.DataModels
{
    public class Donacion
    {
        public int Iddonacion { get; set; }
        public int Idalbergue { get; set; }
        public int Iddonante { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Cantidad { get; set; }

        public virtual Donantes IddonanteNavigation { get; set; }
    }
}
