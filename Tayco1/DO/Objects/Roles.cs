using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Objects
{
    public class Roles
    {
        public Roles()
        {
            Administrador = new HashSet<Administrador>();
            Users = new HashSet<Users>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<Administrador> Administrador { get; set; }
        public ICollection<Users> Users { get; set; }

    }
}
