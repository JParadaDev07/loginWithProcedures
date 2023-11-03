using loginWithProcedures.Entities;
using loginWithProcedures.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loginWithProcedures.Views
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RoleLogic objRoles = new RoleLogic();
            List<RoleEntities> roleData = objRoles.getRole();

            for (int i = 0; i < roleData.Count; i++)
            {
                drplRoles.DataSource = roleData[i];
            }


        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}