using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class TipoCancha
    {
        public TipoCancha()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int TipoCanchaId { get; set; }
        public string NombreCancha { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Reserva> Reserva { get; set; }
    }
}
