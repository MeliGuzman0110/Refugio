using System;
using System.Collections.Generic;

namespace APIW.Models
{
    public partial class Adoptantes
    {
        public Adoptantes()
        {
            Adopcion = new HashSet<Adopcion>();
        }

        public int Idadoptante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Adopcion> Adopcion { get; set; }
    }
}
