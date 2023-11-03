using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace loginWithProcedures.Data
{
    public class Connection
    {
        SqlConnection conn = null;
        string connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
        public Connection()
        {
            conn = new SqlConnection(connectionString);
        }

        public SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        public SqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            return conn;
        }

        public DataTable QueryDatabase(string sp)
        {
            openConnection();

            DataSet ds = new DataSet();
            DataTable data = new DataTable();
            ds.Tables.Add(data);

            SqlCommand cmd = new SqlCommand(sp, conn);
            SqlDataReader result = cmd.ExecuteReader();

            data.Load(result);
            closeConnection();

            return data;

        }


    }
}