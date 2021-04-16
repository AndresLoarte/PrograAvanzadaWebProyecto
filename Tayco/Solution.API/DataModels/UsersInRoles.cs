using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.DataModels
{
    public class UsersInRoles
    {
        public int UserUserId { get; set; }
        public int RoleRoleId { get; set; }

        public Roles RoleRole { get; set; }
        public Users UserUser { get; set; }
    }
}
