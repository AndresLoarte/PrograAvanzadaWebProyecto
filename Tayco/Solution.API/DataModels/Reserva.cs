using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Reserva
    {

        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int TipoCanchaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime Hora { get; set; }
        public bool Estado { get; set; }

        public Cliente Cliente { get; set; }
        public TipoCancha TipoCancha { get; set; }

    }
}
