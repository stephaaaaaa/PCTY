using System;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        private Random generator;
        Employee empToAddDependents;
        private int incomingEmployeeID = 0;
        private bool addingDependentsFromEmployee = false;

        private void getIncomingEmployeeID()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("id="))
            {
                string[] urlPortion = url.Split('=');
                string[] idPortion = urlPortion[1].Split('_');
                incomingEmployeeID = int.Parse(idPortion[1]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getIncomingEmployeeID();
            if (incomingEmployeeID != 0)
            {
                Panel_AddSingleEmployee.Visible = false;
                Panel_AddDependents.Visible = true;
                addingDependentsFromEmployee = true;

                Label employeeName = new Label();
                using (var db = new BenefitsContext())
                {
                    empToAddDependents = db.Employees.FirstOrDefault(p => p.employeeID == incomingEmployeeID);
                }
                employeeName.Text = $"Adding dependents to: {empToAddDependents.firstName} {empToAddDependents.lastName}";
                panel_IncomingEmployeeInfo.Controls.Add(employeeName);
            }
            else
            {
                Panel_AddSingleEmployee.Visible = true;
                Panel_AddDependents.Visible = false;
            }
            generator = new Random();
        }

        #region Generic employee creation helpers
        private Employee createStandardEmployeeWithDependents(string fname, string lname)
        {
            Employee newEmployee = new Employee();
            newEmployee.firstName = fname;
            newEmployee.lastName = lname;
            newEmployee.employeeNumber = generator.Next(0, 999999);
            newEmployee.hasDependent = true;
            newEmployee.cost = 1000;
            newEmployee.paycheckBeforeDeductions = 2000;
            apply10PercentOffIfApplicable(newEmployee);
            newEmployee.deductionsPerPaycheck = newEmployee.cost / 26;
            newEmployee.paycheckAfterDeductions = newEmployee.paycheckBeforeDeductions - newEmployee.deductionsPerPaycheck;

            return newEmployee;
        }

        private void apply10PercentOffIfApplicable(Employee emp)
        {
            if (emp.firstName.ToLower().First().Equals('a'))
            {
                emp.cost -= emp.cost * .10;
            }
        }

        private void apply10PercentOffIfApplicable(Dependent dep)
        {
            if (dep.firstName.ToLower().First().Equals('a'))
            {
                dep.cost -= dep.cost * .10;
            }
        }

        private Employee createStandardEmployeeNoDependents(string fname, string lname)
        {
            Employee newEmployee = new Employee();
            newEmployee.firstName = fname;
            newEmployee.lastName = lname;
            newEmployee.employeeNumber = generator.Next(0, 999999);
            newEmployee.hasDependent = false;
            newEmployee.cost = 1000;
            newEmployee.paycheckBeforeDeductions = 2000;
            apply10PercentOffIfApplicable(newEmployee);
            newEmployee.deductionsPerPaycheck = newEmployee.cost / 26;
            newEmployee.paycheckAfterDeductions = newEmployee.paycheckBeforeDeductions - newEmployee.deductionsPerPaycheck;

            return newEmployee;
        }
        #endregion

        #region dependent creation helpers
        private Dependent createInitialDependent(int employeeID, string firstName, string lastName)
        {
            Dependent newDependent = new Dependent();

            newDependent.firstName = firstName;
            newDependent.lastName = lastName;
            newDependent.cost = 500;
            apply10PercentOffIfApplicable(newDependent);

            return newDependent;
        }

        private void createDependentsFromFields(Employee newEmployee)
        {
            for (int i = 0; i < Request.Form.Count; i++)
            {
                Dependent newDependent = new Dependent();

                if (Request.Form.AllKeys[i].Contains("dep_firstname"))
                {
                    int dep_firstNameIndex = Request.Form.AllKeys[i].IndexOf("dep_firstname");
                    int dep_firstNameLength = Request.Form.AllKeys[i].Length - dep_firstNameIndex;
                    string[] dep_firstNameValue = Request.Form.AllKeys[i].Substring(dep_firstNameIndex, dep_firstNameLength).Split('$');

                    if (dep_firstNameValue[0].Contains("dep_firstname"))
                    {
                        if (passedFirstDependentField) // multiple dependents
                        {
                            string[] firstnames = Request.Form[i].Split(',');
                            if (firstnames[0].Equals("")) break;
                            i++;
                            string[] lastNames = Request.Form[i].Split(',');
                            for (int extraDependentCount = 0; extraDependentCount < firstnames.Length; extraDependentCount++)
                            {
                                newDependent = new Dependent();
                                newDependent.employeeID = newEmployee.employeeID;

                                if (!firstnames[extraDependentCount].Equals("") && !lastNames[extraDependentCount].Equals(""))
                                {
                                    newDependent.firstName = firstnames[extraDependentCount];
                                    newDependent.lastName = lastNames[extraDependentCount];
                                    newDependent.cost = 500;
                                    apply10PercentOffIfApplicable(newDependent);
                                    using (var db = new BenefitsContext())
                                    {
                                        Employee toUpdate = db.Employees.FirstOrDefault(p => p.employeeID == newEmployee.employeeID);
                                        toUpdate.cost += newDependent.cost;
                                        toUpdate.deductionsPerPaycheck = toUpdate.cost / 26;
                                        toUpdate.paycheckAfterDeductions = toUpdate.paycheckBeforeDeductions - toUpdate.deductionsPerPaycheck;

                                        db.Dependents.Add(newDependent);
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                        string firstName = Request.Form[i];
                        i++;
                        string lastName = Request.Form[i];
                        newDependent = createInitialDependent(newEmployee.employeeID, firstName, lastName);
                        if (addingDependentsFromEmployee)
                            newDependent.employeeID = incomingEmployeeID;
                        else
                            newDependent.employeeID = newEmployee.employeeID;
                    }

                    if (!passedFirstDependentField)
                    {
                        using (var db = new BenefitsContext())
                        {
                            if (!addingDependentsFromEmployee)
                            {
                                Employee toUpdate = db.Employees.FirstOrDefault(p => p.employeeID == newEmployee.employeeID);
                                toUpdate.cost += newDependent.cost;
                                toUpdate.deductionsPerPaycheck = toUpdate.cost / 26;
                                toUpdate.paycheckAfterDeductions = toUpdate.paycheckBeforeDeductions - toUpdate.deductionsPerPaycheck;
                            }
                            else
                            {
                                Employee toUpdate = db.Employees.FirstOrDefault(p => p.employeeID == incomingEmployeeID);
                                toUpdate.cost += newDependent.cost;
                                toUpdate.deductionsPerPaycheck = toUpdate.cost / 26;
                                toUpdate.paycheckAfterDeductions = toUpdate.paycheckBeforeDeductions - toUpdate.deductionsPerPaycheck;
                            }
                            db.Dependents.Add(newDependent);
                            db.SaveChanges();
                        }
                        passedFirstDependentField = true;
                    }
                }
            }
        }
        #endregion

        #region Button functionality

        protected void Button_SubmitEmployeeWithNoDependents_Click(object sender, EventArgs e)
        {
            string fname = TextBox_EmployeeFirstName.Text;
            string lname = TextBox_EmployeeLastName.Text;

            Employee newEmployee = createStandardEmployeeNoDependents(fname, lname);

            using (var db = new BenefitsContext())
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }
            Response.Redirect("~/ViewEmployees.aspx");
        }

        protected void Button_SubmitWithDependents_Click(object sender, EventArgs e)
        {
            string employee_fname = TextBox_EmployeeFirstName.Text;
            string employee_lname = TextBox_EmployeeLastName.Text;

            Employee newEmployee = createStandardEmployeeWithDependents(employee_fname, employee_lname);
            using (var db = new BenefitsContext())
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("dep_FirstName")) // indicates that the text boxes exist
                {
                    Dependent newDependent = new Dependent();
                    newDependent.cost = 500;

                    int ParamStartPoint = Request.Form.AllKeys[i].IndexOf("dep_First");
                    int ParamNameLength = Request.Form.AllKeys[i].Length - ParamStartPoint - 1;

                    string[] ControlName = Request.Form.AllKeys[i].Substring(ParamStartPoint, ParamNameLength).Split('$');

                    if (ControlName[0] == "dep_FirstName")
                    {
                        newDependent.firstName = Request.Form[i];
                    }
                    i++;
                    if (Request.Form.AllKeys[i].Contains("dep_LastName")) // indicates that the text boxes exist
                    {
                        int ParamStartPoint2 = Request.Form.AllKeys[i].IndexOf("dep_Last");
                        int ParamNameLength2 = Request.Form.AllKeys[i].Length - ParamStartPoint2 - 1;

                        string[] ControlName2 = Request.Form.AllKeys[i].Substring(ParamStartPoint2, ParamNameLength2).Split('$');

                        if (ControlName2[0] == "dep_LastName")
                        {
                            newDependent.lastName = Request.Form[i];
                        }
                    }
                    apply10PercentOffIfApplicable(newDependent);
                    newEmployee.cost += newDependent.cost;
                    newDependent.employeeID = newEmployee.employeeID;
                    //newDependent.Employee.id = newEmployee.id;
                    using (var db = new BenefitsContext())
                    {
                        db.Dependents.Add(newDependent);
                        Employee employeeToUpdate = db.Employees.Find(newEmployee.employeeID);
                        employeeToUpdate.cost = newEmployee.cost;
                        employeeToUpdate.deductionsPerPaycheck = employeeToUpdate.cost / 26;
                        employeeToUpdate.paycheckBeforeDeductions = 2000;
                        employeeToUpdate.paycheckAfterDeductions = employeeToUpdate.paycheckBeforeDeductions - employeeToUpdate.deductionsPerPaycheck;
                        db.SaveChanges();
                    }
                }
            }

            Response.Redirect("~/ViewEmployees.aspx");
        }

        protected void button_addDependents_Click(object sender, EventArgs e)
        {
            button_cancel.Visible = false;
            Button_addDependents.Visible = false;
            Button_SubmitEmployeeWithNoDependents.Text = "Submit with no dependents";
            Panel_AddDependents.Visible = true;
        }

        bool passedFirstDependentField = false;

        /// <summary>
        /// Submits a brand new employee with dependents, or adds a dependent to an existing
        /// employee. The latter entails database updates for dependent status, cost, etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_submitEmployeeWithDependent_Click(object sender, EventArgs e)
        {
            if (incomingEmployeeID == 0) // if the employee is brand new
            {
                string emp_fName = TextBox_EmployeeFirstName.Text;
                string emp_lName = TextBox_EmployeeLastName.Text;
                Employee newEmployee = createStandardEmployeeWithDependents(emp_fName, emp_lName);

                using (var db = new BenefitsContext())
                {
                    db.Employees.Add(newEmployee);
                    db.SaveChanges();
                }
                createDependentsFromFields(newEmployee);
                Response.Redirect("ViewEmployees.aspx");
            }
            else // if the employee exists and is getting added dependents
            {
                using (var db = new BenefitsContext())
                {
                    Employee toUpdate = db.Employees.FirstOrDefault(p => p.employeeID == incomingEmployeeID);
                    if (toUpdate.hasDependent == false)
                        toUpdate.hasDependent = true;
                    createDependentsFromFields(toUpdate);
                    db.SaveChanges();
                }
                // redirect back to their closer details page
                Response.Redirect($"CloserDetails?id={incomingEmployeeID}");
            }
        }

        /// <summary>
        /// Cancel button to take the user back to either the homepage, or the view
        /// employees page. Depends on which page they accessed the add functionality
        /// from.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void button_cancel_Click(object sender, EventArgs e)
        {
            if (!addingDependentsFromEmployee)
                Response.Redirect("Default.aspx");
            else
                Response.Redirect($"CloserDetails?id={incomingEmployeeID}");
        }
        #endregion

    }
}