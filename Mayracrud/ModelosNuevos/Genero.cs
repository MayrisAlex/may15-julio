using System;
using System.Collections.Generic;

#nullable disable

namespace Mayracrud.ModelosNuevos
{
    public partial class Genero
    {
        public Genero()
        {
            Personas = new HashSet<Persona>();
        }

        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public virtual ICollection<Persona> Personas { get; set; }
    }
}
