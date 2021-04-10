using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Solution.API.W.Models
{
    public partial class UsersInRoles
    {
        public int UserUserId { get; set; }
        public int RoleRoleId { get; set; }

        public virtual Roles RoleRole { get; set; }
        public virtual Users UserUser { get; set; }
    }
}
