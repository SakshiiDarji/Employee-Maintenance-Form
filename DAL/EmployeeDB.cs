using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_ConnectedMode.DAL;
using Lab1_ConnectedMode.BLL;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Lab1_ConnectedMode.DAL

    //sqlReader  : Providing a way to read forward-only (not back-word) in sql server database 
    //for Oracle : OracleDataReader
{
    public static class EmployeeDB
    {
        // 1. save a record 

        public static void saveRecord(Employee emp)
        {
            //step 1 : open DB

            SqlConnection conn = UtilityDB.getDBConnection();

            //step 2 :perform INSERT operation
            //create and customize object of Sqlcommand 

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = conn;

            //2 versions to write command text 

            //version-1

            //cmdInsert.CommandText = "INSERT INTO Employees " +
            //                           "VALUES(" + emp.EmployeeId + ",'" +
            //                                       emp.FirstName + "','" +
            //                                       emp.LastName + "','" +
            //                                       emp.JobTitle + "')";


            //version-2

            cmdInsert.CommandText = "INSERT INTO Employees (EmployeeId, FirstName, LastName, JobTitle) " +
                                    "VALUES(@EmployeeId, @FirstName, @LastName, @JobTitle)";

            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("@JobTitle", emp.JobTitle);

              cmdInsert.ExecuteNonQuery();
           

            //step 3 : close DB
            conn.Close();
        }

        // 2. search a record 

        // search employee by EmployeeId
        // If found ==> how many records tobe returned = 1 

        // search employee by FirstName/ LastName / FirstName + LastName
        // If found ==> how many records tobe returned = 1 

        public static Employee searchEmployee(int id)
        {
            Employee emp = new Employee();

            SqlConnection conn = UtilityDB.getDBConnection();

            SqlCommand cmdSearchById = new SqlCommand();
            cmdSearchById.Connection = conn;

            cmdSearchById.CommandText = "SELECT * FROM Employees " +
                                        "WHERE EmployeeId = @EmployeeId";

            cmdSearchById.Parameters.AddWithValue("@EmployeeId", id);

            SqlDataReader reader = cmdSearchById.ExecuteReader();
            if(reader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString().Trim();
                emp.LastName = reader["LastName"].ToString().Trim();
                emp.JobTitle = reader["JobTitle"].ToString().Trim();

            }

            else
            {
                emp = null;
            }
            conn.Close();
            return emp;
        }

        public static List<Employee> searchEmployee(String input)   //First name or last name
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.getDBConnection();

            SqlCommand cmdSearchByName = new SqlCommand();
            cmdSearchByName.Connection = conn;

            cmdSearchByName.CommandText = "SELECT * FROM Employees " +
                                        "WHERE FirstName = @FirstName" +
                                        " or LastName = @LastName";

            cmdSearchByName.Parameters.AddWithValue("@FirstName", input);
            cmdSearchByName.Parameters.AddWithValue("@LastName", input);

            SqlDataReader reader = cmdSearchByName.ExecuteReader();

            Employee emp;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString().Trim();
                    emp.LastName = reader["LastName"].ToString().Trim();
                    emp.JobTitle = reader["JobTitle"].ToString().Trim();
                    listE.Add( emp );
                }
            }

            conn.Close ();
            return listE;
        }

        public static List<Employee> searchEmployee(String input1, String input2) //First name and last name 
        {
            List<Employee> listE = new List<Employee>();
            SqlConnection conn = UtilityDB.getDBConnection();

            SqlCommand cmdSearchByBothName = new SqlCommand();
            cmdSearchByBothName.Connection = conn;

            cmdSearchByBothName.CommandText = "SELECT * FROM Employees " +
                                        "WHERE FirstName = @FirstName" +
                                        " and LastName = @LastName";

            cmdSearchByBothName.Parameters.AddWithValue("@FirstName", input1);
            cmdSearchByBothName.Parameters.AddWithValue("@LastName", input2);

            SqlDataReader reader = cmdSearchByBothName.ExecuteReader();

            Employee emp;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString().Trim();
                    emp.LastName = reader["LastName"].ToString().Trim();
                    emp.JobTitle = reader["JobTitle"].ToString().Trim();
                    listE.Add(emp);
                }
            }

            conn.Close();
            return listE;
        }



        public static void updateEmployee(Employee empUpdated)
        {
            SqlConnection conn = UtilityDB.getDBConnection();

            SqlCommand cmdUpdateEmp = new SqlCommand();
            cmdUpdateEmp.Connection = conn;

            cmdUpdateEmp.CommandText = "UPDATE Employees " +
                                        "   Set FirstName = @FirstName," +
                                        "       LastName = @LastName," +
                                        "       JobTitle = @JobTitle" +
                                        " WHERE EmployeeId = @EmployeeId";

            cmdUpdateEmp.Parameters.AddWithValue("@EmployeeId", empUpdated.EmployeeId);
            cmdUpdateEmp.Parameters.AddWithValue("@FirstName", empUpdated.FirstName);
            cmdUpdateEmp.Parameters.AddWithValue("@LastName", empUpdated.LastName);
            cmdUpdateEmp.Parameters.AddWithValue("@JobTitle", empUpdated.JobTitle);

            cmdUpdateEmp.ExecuteNonQuery();
            conn.Close();
        }

        public static bool IsUniqueId(int eId)
        {
            Employee emp = searchEmployee(eId);
            if (emp != null)
            {
                return false;
            }
            return true;
        }

        public static void deleteEmployee(int idDelete)
        {

            SqlConnection conn = UtilityDB.getDBConnection();

            SqlCommand cmdDeleteEmp = new SqlCommand();
            cmdDeleteEmp.Connection = conn;

            cmdDeleteEmp.CommandText = "DELETE Employees " +
                                     "WHERE EmployeeId=@EmployeeId";

            cmdDeleteEmp.Parameters.AddWithValue("@EmployeeId", idDelete);
            cmdDeleteEmp.ExecuteNonQuery();
            conn.Close();
        }





        // 3. list all the records 

        public static List<Employee> getAllRecords()
        {
            List<Employee> listE = new List<Employee>();

            SqlConnection conn = UtilityDB.getDBConnection();

            //SqlCommand cmdSelectAll = new SqlCommand();
            //cmdSelectAll.Connection = conn;
            //cmdSelectAll.CommandText = "SELECT * FROM Employees";

            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", conn);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();  //Applied to SELECT 

            Employee emp;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
                listE.Add( emp );
            }
            conn.Close();

            return listE;
        }




    }
}
