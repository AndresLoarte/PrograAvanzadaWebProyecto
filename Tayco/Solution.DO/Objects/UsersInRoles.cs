using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class UsersInRoles
    {
        [Key]
        public int UserUserId { get; set; }
        [Key]
        public int RoleRoleId { get; set; }

        public virtual Roles RoleRole { get; set; }
        public virtual Users UserUser { get; set; }
    }
}
