using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;       //required for sql server database;    ADO.Net Object Model 
using System.Configuration;

/*
 ADO : (A = active), (D = Data), (O = Objects)
 */

namespace Lab1_ConnectedMode.DAL
{
    public static class UtilityDB
    {
        //public static SqlConnection getDBConnection()
        //{
        //    SqlConnection conn = new SqlConnection();
        //    conn.ConnectionString = "server=SAKSHII\\SQL119EXPRESS;database=EmployeeDB;user=sa;password=Kiara111";
        //    conn.Open();
        //    return conn;
        //}

        public static SqlConnection getDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}
