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
        public int cost;

        public EmployeeObject(string fname, string lname, bool hasDeps)
        {
            Random idGenerator = new Random();

            firstName = fname;
            lastName = lname;
            employeeID = idGenerator.Next(0, 999999).ToString("D5");
            hasDependent = hasDeps;
            hasDependent = false;
            dependents = new List<DependentObject>();
            cost = 1000; // an employee by themselves costs $1000
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

        public int getDependentsCount()
        {
            if (dependents.Equals(null))
                return 0;

            return dependents.Count;
        }

        public void addDependent(DependentObject dependent)
        {
            hasDependent = true;
            dependents.Add(dependent);
            cost += 500;
        }

        public List<DependentObject> getDependents()
        {
            return dependents;
        }

        public string getCost()
        {
            return cost.ToString("C2");
        }
    }
}