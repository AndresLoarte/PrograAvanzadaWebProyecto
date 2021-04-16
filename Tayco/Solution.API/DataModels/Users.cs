using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class Users
    {
      

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool? Estado { get; set; }

        //public ICollection<Administrador> Administrador { get; set; }
        //public ICollection<Cliente> Cliente { get; set; }
        //public ICollection<UsersInRoles> UsersInRoles { get; set; }

    }
}
