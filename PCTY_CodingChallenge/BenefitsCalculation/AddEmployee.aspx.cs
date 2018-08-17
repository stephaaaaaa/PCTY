using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        private Random generator;

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel_AddSingleEmployee.Visible = true;
            Panel_AddDependents.Visible = false;
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
            Button_addDependents.Visible = false;
            Button_SubmitEmployeeWithNoDependents.Text = "Submit with no dependents";
            Panel_AddDependents.Visible = true;
        }

        protected void button_submitEmployeeWithDependent_Click(object sender, EventArgs e)
        {
            string emp_fName = TextBox_EmployeeFirstName.Text;
            string emp_lName = TextBox_EmployeeLastName.Text;
            Employee newEmployee = createStandardEmployeeWithDependents(emp_fName, emp_lName);

            // add the new employee and generate their db id
            using (var db = new BenefitsContext())
            {
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }

            bool passedFirstDependentField = false;
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
                        newDependent = new Dependent();
                        newDependent.employeeID = newEmployee.employeeID;

                        newDependent.firstName = Request.Form[i];
                        i++;
                        newDependent.lastName = Request.Form[i];
                        newDependent.cost = 500;
                        apply10PercentOffIfApplicable(newDependent);
                    }

                    if (!passedFirstDependentField)
                    {
                        using (var db = new BenefitsContext())
                        {
                            Employee toUpdate = db.Employees.FirstOrDefault(p => p.employeeID == newEmployee.employeeID);
                            toUpdate.cost += newDependent.cost;
                            toUpdate.deductionsPerPaycheck = toUpdate.cost / 26;
                            toUpdate.paycheckAfterDeductions = toUpdate.paycheckBeforeDeductions - toUpdate.deductionsPerPaycheck;

                            db.Dependents.Add(newDependent);
                            db.SaveChanges();
                        }
                        passedFirstDependentField = true;
                    }
                }
            }
            Response.Redirect("ViewEmployees.aspx");
        }
    }
}