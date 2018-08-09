using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{
    public class DependentObject
    {
        private static string firstName;
        private static string lastName;
        private static string respectiveDependent;

        public DependentObject(string fname, string lname, string parentOrSpouse)
        {
            firstName = fname;
            lastName = lname;
            respectiveDependent = parentOrSpouse;
        }

        public string getName()
        {
            return $"{firstName} {lastName}";
        }

        public string getProvider()
        {
            return $"{respectiveDependent}";
        }

    }
}