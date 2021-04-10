using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class Users
    {
        public Users()
        {
            Administrador = new HashSet<Administrador>();
            Cliente = new HashSet<Cliente>();
            UsersInRoles = new HashSet<UsersInRoles>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }

    }
}
