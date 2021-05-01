using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FrontEnd.API.Models
{
    public partial class User
    {
        public User()
        {
            Reserva = new HashSet<Reserva>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int Telefono { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public int RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
