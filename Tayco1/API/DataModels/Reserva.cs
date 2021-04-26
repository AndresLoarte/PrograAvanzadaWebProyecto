using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int UserId { get; set; }
        public int TipoCanchaId { get; set; }
        public int EquipoId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime Hora { get; set; }
        public bool Estado { get; set; }

        public Equipo Equipo { get; set; }
        //public TipoCancha TipoCancha { get; set; }
        //public Users User { get; set; }
    }
}
