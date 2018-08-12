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
        private int cost;

        public EmployeeObject(string fname, string lname, bool hasDeps)
        {
            Random idGenerator = new Random();

            firstName = fname;
            lastName = lname;
            hasDependent = hasDeps;
            dependents = new List<DependentObject>();
            cost = 1000; // an employee by themselves costs $1000
            employeeID = 0.ToString("D5");
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

        //public void setNumberOfDependents(int count)
        //{
        //    dependentCount = count;
        //}

        public int getDependentsCount()
        {
            return dependentCount;
        }

        public void addDependent(DependentObject dependent)
        {
            cost += 500;
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
    }
}