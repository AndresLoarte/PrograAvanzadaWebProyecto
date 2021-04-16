using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Auditoria
    {
        public int AuditoriaId { get; set; }
        public string UserName { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public int ReservaId { get; set; }

        public Reserva Reserva { get; set; }
    }
}
