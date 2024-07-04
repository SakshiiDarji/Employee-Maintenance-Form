using Lab1_ConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1_ConnectedMode.VALIDATION;


namespace Lab1_ConnectedMode.GUI
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void buttonListEmployees_Click(object sender, EventArgs e)
        {
            listViewEmployee.Items.Clear();

            Employee employee = new Employee();
            List<Employee> listE = employee.getEmployeeList();

            foreach (Employee emp in listE)
            {
                ListViewItem item = new ListViewItem(emp.EmployeeId.ToString());
                item.SubItems.Add(emp.FirstName);
                item.SubItems.Add(emp.LastName);
                item.SubItems.Add(emp.JobTitle);
                listViewEmployee.Items.Add(item);
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Do you really want to exit the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string input = textBoxEmployeeId.Text.Trim();

            if (!Validators.isValidId(input,4))
            {
                MessageBox.Show("Employee Id must be 4-digit number.", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            Employee emp = new Employee();

            if (!emp.isUniqId(Convert.ToInt32(input))){
                MessageBox.Show("Employee Id must be unique.\n" + "Please enter another EmployeeId.", "Duplicate EmployeeId", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmployeeId.Clear();
                textBoxEmployeeId.Focus();
                return;
            }

            input = textBoxFirstName.Text.Trim();

            if (!Validators.isValidName(input))
            {
                MessageBox.Show("Invalid First Name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxFirstName.Clear();
                textBoxFirstName.Focus();
                return;
            }

            input = textBoxLastName.Text.Trim();

            if (!Validators.isValidName(input))
            {
                MessageBox.Show("Invalid Last Name.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Clear();
                textBoxLastName.Focus();
                return;
            }

            input = textBoxJobTitle.Text.Trim();

            if (!Validators.isValidName(input))
            {
                MessageBox.Show("Invalid Job Title.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxJobTitle.Clear();
                textBoxJobTitle.Focus();
                return;
            }

                emp.FirstName = textBoxFirstName.Text;
                emp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text);
                emp.LastName = textBoxLastName.Text;
                emp.JobTitle = textBoxJobTitle.Text;

                emp.saveEmployee(emp);
                MessageBox.Show("Employee data has been updated successfully.", "Confirmation", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Employee employeeUpdate = new Employee();
            employeeUpdate.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());
            employeeUpdate.FirstName = textBoxFirstName.Text.Trim();
            employeeUpdate.LastName = textBoxLastName.Text.Trim();
            employeeUpdate.JobTitle = textBoxJobTitle.Text.Trim();

            bool doesNotExist  = employeeUpdate.isUniqId(employeeUpdate.EmployeeId);
            
            if(doesNotExist == false)
            {
                employeeUpdate.updateEmployee(employeeUpdate);
                MessageBox.Show("Employee data has been updated successfully.", "Confirmation", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Employee Doesn't Exist, please Try again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
           
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(comboBoxSearch.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Search option first.", "Search Option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String input = "";
            Employee emp = new Employee();

            switch(comboBoxSearch.SelectedIndex)
            {

                case 0:
                    input = textBoxInput.Text.Trim();
                    if (!Validators.isValidId(input, 4))
                    {
                        MessageBox.Show("Employee Id must be 4-digit number.", "Invalid Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    emp = emp.searchEmployee(Convert.ToInt32(input));

                    if(emp != null)
                    {
                        textBoxEmployeeId.Text = emp.EmployeeId.ToString();
                        textBoxFirstName.Text = emp.FirstName.ToString();
                        textBoxLastName.Text = emp.LastName.ToString();
                        textBoxJobTitle.Text = emp.JobTitle.ToString();
                    }

                    else
                    {
                        MessageBox.Show("Employee not found!", "Invalid Employee Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    break;

                case 1:

                    input = textBoxInput.Text.Trim();
                    List<Employee> listE = new List<Employee>();

                    listE = emp.searchEmployee(input);
                    listViewEmployee.Items.Clear();

                    if (listE.Count == 0)
                    {
                        MessageBox.Show("Employee not found!", "Invalid First Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    else
                    {
                        foreach (Employee empItem in listE)
                        {
                            ListViewItem item = new ListViewItem(empItem.EmployeeId.ToString());
                            item.SubItems.Add(empItem.FirstName);
                            item.SubItems.Add(empItem.LastName);
                            item.SubItems.Add(empItem.JobTitle);
                            listViewEmployee.Items.Add(item);
                        }
                    }
                    break;

                case 2:
                    input = textBoxInput.Text.Trim();
                    List<Employee> listEmp = new List<Employee>();

                    listEmp = emp.searchEmployee(input);
                    listViewEmployee.Items.Clear();

                    if (listEmp.Count == 0)
                    {
                        MessageBox.Show("Employee not found!", "Invalid Last Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput.Focus();
                        return;
                    }
                    else
                    {
                        foreach (Employee empItem in listEmp)
                        {
                            ListViewItem item = new ListViewItem(empItem.EmployeeId.ToString());
                            item.SubItems.Add(empItem.FirstName);
                            item.SubItems.Add(empItem.LastName);
                            item.SubItems.Add(empItem.JobTitle);
                            listViewEmployee.Items.Add(item);
                        }
                    }
                    break;

                case 3:
                    
                    string input1 = textBoxInput.Text.Trim();
                    string input2 = textBoxInput2.Text.Trim();
                    List<Employee> list3 = new List<Employee>();

                    list3 = emp.searchEmployee(input1, input2);
                    listViewEmployee.Items.Clear();

                    if (list3.Count == 0)
                    {
                        MessageBox.Show("Employee not found!", "Invalid Names", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBoxInput.Clear();
                        textBoxInput2.Clear();
                        textBoxInput2.Focus();
                        textBoxInput.Focus();
                        return;
                    }
                    else
                    {
                        foreach (Employee empItem in list3)
                        {
                            ListViewItem item = new ListViewItem(empItem.EmployeeId.ToString());
                            item.SubItems.Add(empItem.FirstName);
                            item.SubItems.Add(empItem.LastName);
                            item.SubItems.Add(empItem.JobTitle);
                            listViewEmployee.Items.Add(item);
                        }
                    }
                    break;

                default:
                    break;


            }


        }

    

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Employee empDeleted = new Employee();
            empDeleted.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text.Trim());

            bool doesNotExist = empDeleted.isUniqId(empDeleted.EmployeeId);

            if (doesNotExist == false)
            {

                var answer = MessageBox.Show("Do you really want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (answer == DialogResult.Yes)
                {
                    empDeleted.deleteEmployee(empDeleted.EmployeeId);
                    MessageBox.Show("Employee data has been deleted successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                textBoxInput.Clear();
                textBoxInput.Focus();
            }

            else
            {
                MessageBox.Show("Employee Doesn't Exist, please Try again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            labelLName.Visible = false;
            textBoxInput2.Visible = false;
        }

        private void ComboBoxSearch_SelectedIndexChaged(object sender, EventArgs e)
        {
            int selectedInt = comboBoxSearch.SelectedIndex;

            switch(selectedInt)
            {
                case 0:
                    labelLName.Visible = false;
                    textBoxInput2.Visible = false;
                    labelMessage.Text = "Please enter Employee Id.";
                    textBoxInput.Clear();
                    textBoxInput2.Clear();
                    break;

                case 1:
                    labelLName.Visible = false;
                    textBoxInput2.Visible = false;
                    labelMessage.Text = "Please enter First Name.";
                    textBoxInput.Clear();
                    textBoxInput2.Clear();
                    break;

                case 2:
                    labelLName.Visible = false;
                    textBoxInput2.Visible = false;
                    labelMessage.Text = "Please enter Last Name.";
                    textBoxInput.Clear();
                    textBoxInput2.Clear();
                    break;

                case 3:
                    labelLName.Visible = true;
                    textBoxInput2.Visible = true;

                    labelMessage.Text = "Please enter First Name.";
                    labelLName.Text = "Please enter Last Name.";
                    textBoxInput.Clear();
                    textBoxInput2.Clear();
                    break;

                default:
                    break;
            }
        }
    }
}
