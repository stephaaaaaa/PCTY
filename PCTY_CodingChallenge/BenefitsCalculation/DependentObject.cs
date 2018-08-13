using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{
    public class DependentObject
    {
        private string firstName;
        private string lastName;
        private string respectiveDependent;

        public DependentObject(string fname, string lname, string parentOrSpouse)
        {
            firstName = uppercaseFirstLetter(fname);
            lastName = uppercaseFirstLetter(lname);
            respectiveDependent = parentOrSpouse;
        }

        private string uppercaseFirstLetter(string name)
        {
            return $"{name.First().ToString().ToUpper()}{name.Substring(1).ToLower()}";
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