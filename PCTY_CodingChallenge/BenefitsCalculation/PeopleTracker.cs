using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{

    public class PeopleTracker
    {
        private List<EmployeeObject> employees;
        private List<int> employeeIDValues;

        public PeopleTracker()
        {
            employees = new List<EmployeeObject>();
            employeeIDValues = new List<int>();
            initializeTestEmployees();
        }

        private void initializeTestEmployees()
        {
            Random generator = new Random();
            int preAssignedID = generator.Next();
            employeeIDValues.Add(preAssignedID);

            EmployeeObject charlieKelly = new EmployeeObject("Charlie", "Kelly", false);
            employees.Add(charlieKelly);
            EmployeeObject frankReynolds = new EmployeeObject("Frank", "Reynolds", true);
            frankReynolds.addDependent(new DependentObject("Deandra", "Reynolds", frankReynolds.getFullName()));
            frankReynolds.addDependent(new DependentObject("Dennis", "Reynolds", frankReynolds.getFullName()));
            employees.Add(frankReynolds);
            EmployeeObject bojackH = new EmployeeObject("Bojack", "Horseman", false);
            employees.Add(bojackH);

        }

        public void addEmployee(EmployeeObject newEmployee)
        {
            employees.Add(newEmployee);
        }

        public void removeEmployee(EmployeeObject employeeToRemove)
        {
            foreach (EmployeeObject employee in employees)
            {
                if (employee.Equals(employeeToRemove))
                {
                    employees.Remove(employeeToRemove);
                }
                //Add a catch for if the employee doesn't exist
            }
        }

        public List<EmployeeObject> viewEmployees()
        {
            return employees;
        }


    }
}