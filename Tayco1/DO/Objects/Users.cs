using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Users
    {
        public Users()
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

        public Roles Role { get; set; }
        public ICollection<Reserva> Reserva { get; set; }

    }
}
