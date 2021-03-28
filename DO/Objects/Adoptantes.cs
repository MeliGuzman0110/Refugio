using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DO.Objects
{
    public class Adoptantes
    {
        public Adoptantes()
        {
            Adopcion = new HashSet<Adopcion>();
        }

        [Key]
        public int Idadoptante { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Adopcion> Adopcion { get; set; }
    }
}
