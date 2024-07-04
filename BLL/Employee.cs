using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Lab1_ConnectedMode.DAL;

// what is class? => A template from which objects are created (bluprint, on which you can create as you want) 

// instance class means that we can create objects from instance class 

//constructors 
//        - default constructor
//        - parameterized constructor 

/*
The lifespan of an object 
    1. Object Declaration 
        Employee emp  // emp : reference type 
    2. Object creation 
        emp = new Employee();
    3. Object Manipulation    // storing data in the object , manipulate object data 
    4. Object Termination     // 


Reference Type : Example : Employee emp = new Employee();
                 emp contains object reference (memory address) to the object of Employee
                 created on the Heap using new operator 
 
 */

namespace Lab1_ConnectedMode.BLL                   
{
    public class Employee           // is instance class 
    {
        //variables / attributes 

        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //properties 

        //(encapsulation)

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }


        //default constructor 
        public Employee() 
        {
            employeeId = 111;
            firstName = string.Empty;
            lastName = string.Empty;
            jobTitle = string.Empty;
        }

        //parameterized constructor 

        public Employee(int id, string firstName, string lastName, string jobTitle)
        {
            this.employeeId = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.jobTitle = jobTitle;
        }

        //custom methods 

        public void saveEmployee(Employee emp)
        {
            EmployeeDB.saveRecord(emp);
        }

        public List<Employee> getEmployeeList()
        {
            return EmployeeDB.getAllRecords();
        }

        public Employee searchEmployee(int id)
        {
            return EmployeeDB.searchEmployee(id);
        }

        public List<Employee> searchEmployee(string input)
        {
            return EmployeeDB.searchEmployee(input);
        }

        public List<Employee> searchEmployee(string input1, string input2)
        {
            return EmployeeDB.searchEmployee(input1, input2);
        }

        public void updateEmployee(Employee empUpdated)
        {
             EmployeeDB.updateEmployee(empUpdated);
        }

        public void deleteEmployee(int id)  => EmployeeDB.deleteEmployee(id);

        public bool isUniqId(int id)
        {
            return EmployeeDB.IsUniqueId(id);
        }

    }
}
