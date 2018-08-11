using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{

    public class PeopleTracker
    {
        private static List<EmployeeObject> employees;
        private static List<DependentObject> dependents;

        public PeopleTracker()
        {
            employees = new List<EmployeeObject>();
            dependents = new List<DependentObject>();
            initializeTestEmployees();
        }

        private void initializeTestEmployees()
        {
            EmployeeObject charlieKelly = new EmployeeObject("Charlie", "Kelly", false);
            employees.Add(charlieKelly);
            EmployeeObject frankReynolds = new EmployeeObject("Frank", "Reynolds", false);
            employees.Add(frankReynolds);
            EmployeeObject bojackH = new EmployeeObject("Bojack", "Horseman", false);
            employees.Add(bojackH);

        }

        public void addEmployee(EmployeeObject newEmployee)
        {
            employees.Add(newEmployee);
        }

        public void addDependent(DependentObject newDependent)
        {
            dependents.Add(newDependent);
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

        public void removeDependent(DependentObject dependentToRemove)
        {
            foreach (DependentObject dependent in dependents)
            {
                if (dependent.Equals(dependentToRemove))
                {
                    dependents.Remove(dependent);
                }
                //Add a catch for if the dependent doesn't exist
            }
        }

        public List<EmployeeObject> viewEmployees()
        {
            return employees;
        }

        public List<DependentObject> viewDependents()
        {
            return dependents;
        }

    }
}