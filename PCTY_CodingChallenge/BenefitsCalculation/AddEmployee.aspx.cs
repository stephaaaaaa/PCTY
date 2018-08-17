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
        private TextBox[] fName_TextBoxes;
        private TextBox[] lName_TextBoxes;
        int dependentCount = 0;
        private Random generator;

        protected void Page_Load(object sender, EventArgs e)
        {
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


        protected void Button_AddDependent_Click(object sender, EventArgs e)
        {
            Button_SubmitEmployeeWithNoDependents.Visible = false;
            Button_AddDependent.Visible = false;

            Panel_AddDependents.Visible = true;
        }

        protected void Button_GenerateDependentFields_Click(object sender, EventArgs e)
        {
            int numberOfDependents = 0;// int.Parse(TextBoxNumberOfDependents.Text);
            RequiredFieldValidator namesFieldValidtor = new RequiredFieldValidator();
            namesFieldValidtor.ErrorMessage = "Please enter a name.";
            namesFieldValidtor.ForeColor.Equals("#db1a32");

            Label[] fName_labels = new Label[numberOfDependents];
            fName_TextBoxes = new TextBox[numberOfDependents];

            Label[] lName_labels = new Label[numberOfDependents];
            lName_TextBoxes = new TextBox[numberOfDependents];

            RegularExpressionValidator namesRegExValidator = new RegularExpressionValidator();
            namesRegExValidator.ErrorMessage = "Do not include symbols other than numerals, punctuation marks, or letters.";
            namesRegExValidator.ForeColor.Equals("#db1a32");
            namesRegExValidator.ValidationExpression = "^[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð ,.'-]+$";

            for (int i = 0; i < numberOfDependents; i++)
            {
                fName_labels[i] = new Label();
                fName_labels[i].CssClass = "row col-lg-2";
                fName_labels[i].Text = $"Dependent {i + 1} first name";

                fName_TextBoxes[i] = new TextBox();
                fName_TextBoxes[i].EnableViewState = true;
                fName_TextBoxes[i].CssClass = "form-control";
                fName_TextBoxes[i].ID = $"dep_FirstName{i}";

                lName_labels[i] = new Label();
                lName_labels[i].CssClass = "row col-lg-2";
                lName_labels[i].Text = $"Dependent {i + 1} last name";


                lName_TextBoxes[i] = new TextBox();
                lName_TextBoxes[i].EnableViewState = true;
                lName_TextBoxes[i].CssClass = "form-control";
                lName_TextBoxes[i].ID = $"dep_LastName{i}";
            }

            for (int i = 0; i < numberOfDependents; i++)
            {
                Panel_DependentsFields.Attributes.Add("class", "row");
                Panel_DependentsFields.Controls.Add(fName_labels[i]);
                Panel_DependentsFields.Controls.Add(fName_TextBoxes[i]); // first name text box
                Panel_DependentsFields.Attributes.Add("class", "row");
                Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
                Panel_DependentsFields.Controls.Add(lName_labels[i]);
                Panel_DependentsFields.Controls.Add(lName_TextBoxes[i]); // last name text box
                Panel_DependentsFields.Attributes.Add("class", "row");
                Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
            }
            Panel_DependentsFields.CssClass = "row";
            Panel_DependentsFields.Visible = true;
            Panel_SubmitWithDependents.Visible = true;
        }

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

        protected void button_addNewDependent_Click(object sender, EventArgs e)
        {
            dependentCount++;
            if (!Panel_AddDependents.Visible == true)
                Panel_AddDependents.Visible = true;

            Panel panel_newDependentPanel = new Panel();

            Label newDependent_fName = new Label();
            newDependent_fName.Text = $"Dependent first name:";
            Label newDependent_lName = new Label();
            newDependent_lName.Text = $"Dependent last name:";

            TextBox newDependent_fNameText = new TextBox();
            newDependent_fNameText.CssClass = "form-control";
            TextBox newDependent_lNameText = new TextBox();
            newDependent_lNameText.CssClass = "form-control";

            //panel_newDependentFields.Attributes.Add("class", "row");
            panel_newDependentPanel.Controls.Add(newDependent_fName);
            panel_newDependentPanel.Controls.Add(newDependent_fNameText);

            //panel_newDependentFields.Attributes.Add("class", "row");
            panel_newDependentPanel.Controls.Add(newDependent_lName);
            panel_newDependentPanel.Controls.Add(newDependent_lNameText);
            panel_newDependentFields.Controls.Add(panel_newDependentPanel);
        }
    }
}