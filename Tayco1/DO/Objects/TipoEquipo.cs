using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class TipoEquipo
    {
        public TipoEquipo()
        {
            Equipo = new HashSet<Equipo>();
        }

        public int TipoEquipoId { get; set; }
        public string NombreTipo { get; set; }

        public ICollection<Equipo> Equipo { get; set; }
    }
}
