using loginWithProcedures.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace loginWithProcedures.Data
{
    public class RoleData
    {
        //public List<RoleEntities> getRoles()
        //{
        //    Connection conn = new Connection();
        //    DataTable dataTable = conn.QueryDatabase("sp_SelectRole");


        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    sqlDataAdapter.Fill(dataTable);
        //    List<RoleEntities> roleList = new List<RoleEntities>();

        //    foreach (DataRow item in dataTable.Rows)
        //    {
        //        roleList.Add(new RoleEntities()
        //        {
        //            role = item["nombreRol"].ToString()
        //        });
        //    }

        //    return roleList;
        //}


        public List<RoleEntities> getRoles(string roleName)
        {
            Connection conn = new Connection();
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = conn.openConnection())
            using (SqlCommand cmd = new SqlCommand("sp_SelectRole", sqlConnection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@role", roleName);

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                {
                    sqlDataAdapter.Fill(dataTable);
                }

                List<RoleEntities> roleList = new List<RoleEntities>();

                foreach (DataRow item in dataTable.Rows)
                {
                    roleList.Add(new RoleEntities()
                    {
                        role = item["nombreRol"].ToString()
                    });
                }

                return roleList;
            }

        }

    }
}