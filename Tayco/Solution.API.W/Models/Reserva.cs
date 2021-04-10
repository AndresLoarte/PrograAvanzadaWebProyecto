using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class Reserva
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

        public virtual Cliente Cliente { get; set; }
        public virtual TipoCancha TipoCancha { get; set; }
        public virtual ICollection<Auditoria> Auditoria { get; set; }
    }
}
