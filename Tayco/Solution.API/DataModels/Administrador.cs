using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Administrador
    {
        public int AdministradorId { get; set; }

        public string NombreAdministrador { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        public int? Telefono { get; set; }

        public bool? Estado { get; set; }

        public int? UsuarioId { get; set; }
    }
}
