using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Observaciones
    {
        public int ObservacionesId { get; set; }
        public string NombreCliente { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
