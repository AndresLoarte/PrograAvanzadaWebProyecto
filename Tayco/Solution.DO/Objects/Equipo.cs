using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
   public class Equipo
    {
        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; }
        public int Cantidad { get; set; }
        public int TipoEquipoId { get; set; }
        public bool Estado { get; set; }

        public virtual TipoEquipo TipoEquipo { get; set; }
    }
}
