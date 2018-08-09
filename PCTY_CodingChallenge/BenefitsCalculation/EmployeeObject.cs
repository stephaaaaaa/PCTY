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
        private static int employeeID;
        private static bool hasDependent;
        private static List<DependentObject> dependents;

        public EmployeeObject(string fname, string lname, int ID, bool hasDeps)
        {
            firstName = fname;
            lastName = lname;
            employeeID = ID;
            hasDependent = hasDeps;
            hasDependent = false;
            dependents = null;
        }

        public string getName()
        {
            return $"{firstName} {lastName}";
        }

        public int getID()
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