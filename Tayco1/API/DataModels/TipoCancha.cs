using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DataModels
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
