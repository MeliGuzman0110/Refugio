using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefugioAnimal.DataModels
{
    public class Adopcion
    {
        public int Idadopcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Idadoptante { get; set; }
        public string Tipo { get; set; }
        public string Raza { get; set; }
        public string Edad { get; set; }

        public virtual Adoptantes IdadoptanteNavigation { get; set; }
    }
}
