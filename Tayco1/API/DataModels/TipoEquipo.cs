using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
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
