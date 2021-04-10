using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Auditoria
    {
        public int AuditoriaId { get; set; }
        public string UserName { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public int ReservaId { get; set; }

        public virtual Reserva Reserva { get; set; }
    }
}
