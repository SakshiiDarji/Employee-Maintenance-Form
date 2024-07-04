using Lab1_ConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1_ConnectedMode.DAL;
using System.Data.SqlClient;

namespace Lab1_ConnectedMode.GUI
{
    public partial class FormTest : Form
    {
        Employee emp = new Employee();

        public FormTest()
        {
            InitializeComponent();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            emp.EmployeeId = 111;
            emp.FirstName = "Sakshi";
            emp.LastName = "Darji";
            emp.JobTitle = "Teacher";
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            string display = emp.EmployeeId + " " + emp.FirstName + " " + emp.LastName;
            MessageBox.Show(display, "Employee Info", MessageBoxButtons.OK);
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void buttonDB_Click(object sender, EventArgs e)
        {
            SqlConnection conn = UtilityDB.getDBConnection();
            MessageBox.Show("Database connection is " + conn.State.ToString());
        }

        private void buttonSaveEmp_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.FirstName = "Savi";
            emp.EmployeeId = 3333;
            emp.LastName = "Shah";
            emp.JobTitle = "Software Developer C#";

            emp.saveEmployee(emp);
            MessageBox.Show("Saved.");


        }
    }
}
