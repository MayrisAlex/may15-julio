using System;
using System.Collections.Generic;

#nullable disable

namespace Mayracrud.ModelosNuevos
{
    public partial class Persona
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
        public int CodigoGenero { get; set; }

        public virtual Genero CodigoGeneroNavigation { get; set; }
    }
}
