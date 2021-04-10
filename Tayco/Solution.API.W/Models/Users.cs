using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class Users
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
