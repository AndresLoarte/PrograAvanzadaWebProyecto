using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Reserva
    {
        public int ReservaId { get; set; }
        public int UserId { get; set; }
        public int TipoCanchaId { get; set; }
        public int EquipoId { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime Hora { get; set; }
        public bool Estado { get; set; }

        public virtual Equipo Equipo { get; set; }
        public virtual TipoCancha TipoCancha { get; set; }
        public virtual Users User { get; set; }
    }
}
