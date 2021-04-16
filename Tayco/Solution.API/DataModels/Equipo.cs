using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; }
        public int Cantidad { get; set; }
        public int TipoEquipoId { get; set; }
        public bool Estado { get; set; }

        public TipoEquipo TipoEquipo { get; set; }
    }
}
