using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Equipo
    {
        public Equipo()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int EquipoId { get; set; }
        public string NombreEquipo { get; set; }
        public int Cantidad { get; set; }
        public int TipoEquipoId { get; set; }
        public bool Estado { get; set; }

        public TipoEquipo TipoEquipo { get; set; }
        public ICollection<Reserva> Reserva { get; set; }

    }
}
