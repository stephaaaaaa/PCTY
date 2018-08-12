using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{

    public class EmployeeTracker
    {
        private List<EmployeeObject> employees;

        public EmployeeTracker()
        {
            employees = new List<EmployeeObject>();
            initializeTestEmployees();
        }

        private void initializeTestEmployees()
        {
            Random generator = new Random();

            EmployeeObject charlieKelly = new EmployeeObject("Charlie", "Kelly", false);
            charlieKelly.changeID(generator.Next(0, 999999));
            employees.Add(charlieKelly);

            EmployeeObject frankReynolds = new EmployeeObject("Frank", "Reynolds", true);
            frankReynolds.changeID(generator.Next(0, 999999));
            frankReynolds.addDependent(new DependentObject("Deandra", "Reynolds", frankReynolds.getFullName()));
            frankReynolds.addDependent(new DependentObject("Dennis", "Reynolds", frankReynolds.getFullName()));
            employees.Add(frankReynolds);

            EmployeeObject bojackH = new EmployeeObject("Bojack", "Horseman", false);
            bojackH.changeID(generator.Next(0, 999999));
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