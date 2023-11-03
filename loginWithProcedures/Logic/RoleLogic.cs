using loginWithProcedures.Data;
using loginWithProcedures.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginWithProcedures.Logic
{
    public class RoleLogic
    {
        public List<RoleEntities> getRole(string roleName)
        {
            RoleData objRole = new RoleData();
            List<RoleEntities> role = objRole.getRoles(roleName);
            return role;
        }
    }
}