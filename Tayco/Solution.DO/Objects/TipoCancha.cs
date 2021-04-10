using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class TipoCancha
    {
        public TipoCancha()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int TipoCanchaId { get; set; }
        public string NombreCancha { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
