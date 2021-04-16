using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
   public class Reserva
    {
        public Reserva()
        {
            Auditoria = new HashSet<Auditoria>();
        }

        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int TipoCanchaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime Hora { get; set; }
        public bool Estado { get; set; }

        public Cliente Cliente { get; set; }
        public TipoCancha TipoCancha { get; set; }
        public ICollection<Auditoria> Auditoria { get; set; }
    }
}

