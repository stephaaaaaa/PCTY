using System;
using System.Linq;
using System.Web;

namespace BenefitsCalculation
{
    public partial class EditPerson : System.Web.UI.Page
    {
        int incomingPersonID;
        Employee empToEdit;
        Dependent depToEdit;
        bool isEmployee;
        bool isDependent;

        #region Helper methods
        /// <summary>
        /// Method to get the classification of a person (dependent or employee)
        /// based on the URL. Also gets the person's respective ID.
        /// </summary>
        private void getIncomingPersonID()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("id="))
            {
                string[] designation = url.Split('=');
                string[] id = designation[1].Split('_');
                if (id[0].First().Equals('e'))
                    isEmployee = true;
                else if (id[0].First().Equals('d'))
                    isDependent = true;
                incomingPersonID = int.Parse(id[1]);
            }
        }

        /// <summary>
        /// Method for displaying the correct options, depending on if 
        /// the person being edited is a dependent or employee
        /// </summary>
        private void loadCorrectPanel()
        {
            if (isDependent)
                panel_editDependent.Visible = true;
            else if (isEmployee)
                panel_editEmployee.Visible = true;
        }

        /// <summary>
        /// Method for retrieving the changed text box fields for edited first
        /// and last names of dependents.
        /// </summary>
        /// <param name="toSubmit"></param>
        private void getChangedNames(Dependent toSubmit)
        {
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("dependentFName"))
                {
                    int ParamStartPoint = Request.Form.AllKeys[i].IndexOf("dependentFName");
                    int ParamNameLength = Request.Form.AllKeys[i].Length - ParamStartPoint;
                    string[] ControlName = Request.Form.AllKeys[i].Substring(ParamStartPoint, ParamNameLength).Split('$');

                    if (ControlName[0] == "dependentFName")
                    {
                        toSubmit.firstName = Request.Form[i];
                    }
                    i++;
                    if (Request.Form.AllKeys[i].Contains("dependentLName")) // indicates that the text boxes exist
                    {
                        int ParamStartPoint2 = Request.Form.AllKeys[i].IndexOf("dependentLName");
                        int ParamNameLength2 = Request.Form.AllKeys[i].Length - ParamStartPoint2;

                        string[] ControlName2 = Request.Form.AllKeys[i].Substring(ParamStartPoint2, ParamNameLength2).Split('$');

                        if (ControlName2[0] == "dependentLName")
                        {
                            toSubmit.lastName = Request.Form[i];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method for retrieving the changed text box fields for edited first 
        /// and last names of employees.
        /// <param name="toSubmit"></param>
        private void getChangedNames(Employee toSubmit)
        {
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("EmployeeFirstName"))
                {
                    int ParamStartPoint = Request.Form.AllKeys[i].IndexOf("EmployeeFirstName");
                    int ParamNameLength = Request.Form.AllKeys[i].Length - ParamStartPoint;
                    string[] ControlName = Request.Form.AllKeys[i].Substring(ParamStartPoint, ParamNameLength).Split('$');

                    if (ControlName[0] == "EmployeeFirstName")
                    {
                        toSubmit.firstName = Request.Form[i];
                    }
                    i++;
                    if (Request.Form.AllKeys[i].Contains("EmployeeLastName")) // indicates that the text boxes exist
                    {
                        int ParamStartPoint2 = Request.Form.AllKeys[i].IndexOf("EmployeeLastName");
                        int ParamNameLength2 = Request.Form.AllKeys[i].Length - ParamStartPoint2;

                        string[] ControlName2 = Request.Form.AllKeys[i].Substring(ParamStartPoint2, ParamNameLength2).Split('$');

                        if (ControlName2[0] == "EmployeeLastName")
                        {
                            toSubmit.lastName = Request.Form[i];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Method to change the 10% discount for dependents, if necessary
        /// </summary>
        /// <param name="toSubmit"></param>
        /// <param name="firstInitialBeforeChanges"></param>
        /// <param name="firstInitialAfterChanges"></param>
        private void alterDependentDiscount(Dependent toSubmit, char firstInitialBeforeChanges, char firstInitialAfterChanges)
        {
            // if their name didn't start with a, give them a discount
            if (!firstInitialBeforeChanges.Equals('a') && firstInitialAfterChanges.Equals('a'))
            {
                toSubmit.Employee.cost -= toSubmit.cost;
                toSubmit.cost -= toSubmit.cost * .10;
                toSubmit.Employee.cost += toSubmit.cost;
                toSubmit.Employee.deductionsPerPaycheck = toSubmit.Employee.cost / 26;
                toSubmit.Employee.paycheckAfterDeductions = toSubmit.Employee.paycheckBeforeDeductions - toSubmit.Employee.deductionsPerPaycheck;
            }
            // if their name started with a and is changed to a non a name, remove discount
            else if (firstInitialBeforeChanges.Equals('a') && !firstInitialAfterChanges.Equals('a'))
            {
                toSubmit.Employee.cost -= toSubmit.cost;
                toSubmit.cost = 500; // 500 is base dependent cost
                toSubmit.Employee.cost += toSubmit.cost;
                toSubmit.Employee.deductionsPerPaycheck = toSubmit.Employee.cost / 26;
                toSubmit.Employee.paycheckAfterDeductions = toSubmit.Employee.paycheckBeforeDeductions - toSubmit.Employee.deductionsPerPaycheck;
            }
        }

        /// <summary>
        /// Method to change the 10% discount for employees, if necessary
        /// </summary>
        /// <param name="toSubmit"></param>
        /// <param name="firstInitialBeforeChanges"></param>
        /// <param name="firstInitialAfterChanges"></param>
        private void alterEmployeeDiscount(Employee toSubmit, char firstInitialBeforeChanges, char firstInitialAfterChanges)
        {
            // if their name did not start with a and is changed to an a name
            if (!firstInitialBeforeChanges.Equals('a') && firstInitialAfterChanges.Equals('a'))
            {
                toSubmit.cost -= 1000; // 1000 is the base cost
                toSubmit.cost += (1000 - 1000 * .10);
                toSubmit.deductionsPerPaycheck = toSubmit.cost / 26;
                toSubmit.paycheckAfterDeductions = toSubmit.paycheckBeforeDeductions - toSubmit.deductionsPerPaycheck;
            }
            // if their name started with a and is changed to a non a name, remove discount
            else if (firstInitialBeforeChanges.Equals('a') && !firstInitialAfterChanges.Equals('a'))
            {
                toSubmit.cost -= (1000 - (1000 * .10)); // 1000 is the base cost
                toSubmit.cost += 1000;
                toSubmit.deductionsPerPaycheck = toSubmit.cost / 26;
                toSubmit.paycheckAfterDeductions = toSubmit.paycheckBeforeDeductions - toSubmit.deductionsPerPaycheck;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            getIncomingPersonID();
            loadCorrectPanel();

            if (isEmployee)
            {
                empToEdit = new Employee();
                using (var db = new BenefitsContext())
                {
                    empToEdit = db.Employees.FirstOrDefault(p => p.employeeID == incomingPersonID);
                }
                label_employeeBeingEdited.Text = $"Currently editing: {empToEdit.firstName} {empToEdit.lastName}";
                TextBox_EmployeeFirstName.Text = empToEdit.firstName;
                TextBox_EmployeeLastName.Text = empToEdit.lastName;
            }
            else if (isDependent)
            {
                depToEdit = new Dependent();
                using (var db = new BenefitsContext())
                {
                    depToEdit = db.Dependents.FirstOrDefault(p => p.id == incomingPersonID);
                }
                label_dependentBeingEdited.Text = $"Currently editing: {depToEdit.firstName} {depToEdit.lastName}";
                textBox_dependentFName.Text = depToEdit.firstName;
                textBox_dependentLName.Text = depToEdit.lastName;
            }

        }

        #region button functionality

        protected void button_CancelChanges_Click(object sender, EventArgs e)
        {
            if (isDependent) // redirect to the provider page
                Response.Redirect($"CloserDetails?id={depToEdit.employeeID}");
            else
                Response.Redirect($"CloserDetails?id={incomingPersonID}");

        }

        protected void button_SubmitChanges_Click(object sender, EventArgs e)
        {
            var db = new BenefitsContext();

            if (isDependent)
            {
                Dependent toSubmit = db.Dependents.FirstOrDefault(p => p.id == depToEdit.id);
                char firstInitialBeforeChanges = toSubmit.firstName.ToLower().First();
                getChangedNames(toSubmit);
                char firstInitialAfterChanges = toSubmit.firstName.ToLower().First();
                alterDependentDiscount(toSubmit, firstInitialBeforeChanges, firstInitialAfterChanges);

                db.SaveChanges();
                Response.Redirect($"CloserDetails?id={toSubmit.employeeID}");
            }
            else if (isEmployee)
            {
                Employee toSubmit = db.Employees.FirstOrDefault(p => p.employeeID == empToEdit.employeeID);
                char firstInitialBeforeChanges = toSubmit.firstName.ToLower().First();
                getChangedNames(toSubmit);
                char firstInitialAfterChanges = toSubmit.firstName.ToLower().First();

                alterEmployeeDiscount(toSubmit, firstInitialBeforeChanges, firstInitialAfterChanges);
                db.SaveChanges();
                Response.Redirect($"CloserDetails?id={toSubmit.employeeID}");
            }
        }
        #endregion
    }
}