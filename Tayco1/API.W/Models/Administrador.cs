using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.W.Models
{
    public partial class Administrador
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

        public virtual Roles Role { get; set; }
    }
}
