using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Administrador
    {
        public int AdministradorId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NombreAdministrador { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int? Telefono { get; set; }
        public bool Estado { get; set; }
        public int RoleId { get; set; }

        public Roles Role { get; set; }
    }
}
