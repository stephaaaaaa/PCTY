using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{
    public class EmployeeObject
    {
        private static string firstName;
        private static string lastName;
        private static string employeeID;
        private static bool hasDependent;
        private static List<DependentObject> dependents;

        public EmployeeObject(string fname, string lname, bool hasDeps)
        {
            Random idGenerator = new Random();

            firstName = fname;
            lastName = lname;
            employeeID = idGenerator.Next(0, 999999).ToString("D5");
            hasDependent = hasDeps;
            hasDependent = false;
            dependents = null;
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

        public void employeeHasDependents()
        {
            hasDependent = true;
        }

        public List<DependentObject> getDependents()
        {
            return dependents;
        }
    }
}