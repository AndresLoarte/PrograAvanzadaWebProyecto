using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class TipoEquipo
    {
        public TipoEquipo()
        {
            Equipo = new HashSet<Equipo>();
        }

        public int TipoEquipoId { get; set; }
        public string NombreTipo { get; set; }

        public virtual ICollection<Equipo> Equipo { get; set; }
    }
}
