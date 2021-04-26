using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class TipoCancha
    {
        public TipoCancha()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int TipoCanchaId { get; set; }
        public string NombreCancha { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
