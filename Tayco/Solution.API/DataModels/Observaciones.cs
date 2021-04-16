using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
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
