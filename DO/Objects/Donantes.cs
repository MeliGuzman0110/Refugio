using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DO.Objects
{
   public class Donantes
    {
        public Donantes()
        {
            Donacion = new HashSet<Donacion>();
        }

        [Key]
        public int? Iddonante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Donacion> Donacion { get; set; }
    }
}
