using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{
    public class EmployeeObject
    {
        private string firstName;
        private string lastName;
        private string employeeID;
        private bool hasDependent;
        private List<DependentObject> dependents;
        private int dependentCount;
        private double cost;

        public EmployeeObject(string fname, string lname, bool hasDeps)
        {
            Random idGenerator = new Random();

            firstName = fname;
            lastName = lname;
            hasDependent = hasDeps;
            dependents = new List<DependentObject>();
            cost = 1000; // an employee by themselves costs $1000
            employeeID = 0.ToString("D5");

            string lower = firstName.ToLower();
            char first = lower.First();
            if (firstName.ToLower().First().Equals('a')) // their name starts with A
            {
                double discount = cost * .10;
                cost -= discount;
            }

        }

        public string getFullName()
        {
            return $"{firstName} {lastName}";
        }

        public string getLastName()
        {
            return $"{lastName}";
        }

        public string getFirstName()
        {
            return $"{firstName}";
        }

        public string getID()
        {
            return employeeID;
        }

        public void changeID(int newID)
        {
            employeeID = newID.ToString("D5");
        }

        public int getDependentsCount()
        {
            return dependentCount;
        }

        public void addDependent(DependentObject dependent)
        {
            double dependentCost = 500;
            if (dependent.getName().ToLower().First().Equals('a')) // if the dependent name starts with a
            {
                double discount = dependentCost * .10;
                dependentCost -= discount;
            }

            cost += dependentCost;
            dependents.Add(dependent);
            dependentCount++;
        }

        public List<DependentObject> getDependents()
        {
            return dependents;
        }

        public string getCost()
        {
            return cost.ToString("C2");
        }

        public string getDeductionsPerPaycheck()
        {
            int totalPaycheckAmount = 2000;
            int paychecksPerYear = 26;

            double amountToDeduct = cost / paychecksPerYear;
            double amountRemaining = totalPaycheckAmount - amountToDeduct;

            return amountToDeduct.ToString("C2");
        }

        public string getPaycheckAfterDeductions()
        {
            int totalPaycheckAmount = 2000;
            int paychecksPerYear = 26;

            double amountToDeduct = cost / paychecksPerYear;
            double amountRemaining = totalPaycheckAmount - amountToDeduct;

            return amountRemaining.ToString("C2");
        }
    }
}