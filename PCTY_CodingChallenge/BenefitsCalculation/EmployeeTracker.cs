﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{

    public class EmployeeTracker
    {
        private static List<EmployeeObject> employees;

        public EmployeeTracker()
        {
            employees = new List<EmployeeObject>();
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