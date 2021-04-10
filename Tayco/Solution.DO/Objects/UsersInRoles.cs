using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DO.Objects
{
    public class UsersInRoles
    {
        public int UserUserId { get; set; }
        public int RoleRoleId { get; set; }

        public virtual Roles RoleRole { get; set; }
        public virtual Users UserUser { get; set; }
    }
}
