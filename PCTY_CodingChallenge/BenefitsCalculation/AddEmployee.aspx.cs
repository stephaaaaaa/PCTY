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
        //private int numberOfDependents;
        private TextBox[] fName_TextBoxes;
        private TextBox[] lName_TextBoxes;
        private Random generator;

        protected void Page_Load(object sender, EventArgs e)
        {
            generator = new Random();
        }

        protected void Button_AddDependent_Click(object sender, EventArgs e)
        {
            Button_SubmitEmployeeWithNoDependents.Visible = false;
            Button_AddDependent.Visible = false;

            Panel_AddDependents.Visible = true;
        }

        protected void Button_GenerateDependentFields_Click(object sender, EventArgs e)
        {
            int numberOfDependents = int.Parse(TextBoxNumberOfDependents.Text);
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

            using (var db = new BenefitsContext())
            {
                Employee newEmployee = new Employee();
                newEmployee.firstName = fname;
                newEmployee.lastName = lname;
                newEmployee.hasDependent = false;
                newEmployee.employeeNumber = generator.Next(0, 999999);
                newEmployee.cost = 1000;
                newEmployee.paycheckBeforeDeductions = 2000;
                double discount = 0; // discount is 10% if name starts with 'a'
                if (newEmployee.firstName.ToLower().First().Equals('a'))
                {
                    discount = .10;
                    newEmployee.cost -= newEmployee.cost * discount;
                }
                newEmployee.deductionsPerPaycheck = newEmployee.cost/26;
                newEmployee.paycheckAfterDeductions = newEmployee.paycheckBeforeDeductions - newEmployee.deductionsPerPaycheck;
                db.Employees.Add(newEmployee);
                db.SaveChanges();
            }
            Response.Redirect("~/ViewEmployees.aspx");
        }

        protected void Button_SubmitWithDependents_Click(object sender, EventArgs e)
        {
            string employee_fname = TextBox_EmployeeFirstName.Text;
            string employee_lname = TextBox_EmployeeLastName.Text;

            EmployeeObject newEmployee = new EmployeeObject(employee_fname, employee_lname, true);
            newEmployee.changeID(generator.Next(0, 999999));

            string dep_firstName = "";
            string dep_lastName = "";
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("dep_FirstName")) // indicates that the text boxes exist
                {
                    int ParamStartPoint = Request.Form.AllKeys[i].IndexOf("dep_First");
                    int ParamNameLength = Request.Form.AllKeys[i].Length - ParamStartPoint - 1;

                    string[] ControlName = Request.Form.AllKeys[i].Substring(ParamStartPoint, ParamNameLength).Split('$');

                    if (ControlName[0] == "dep_FirstName")
                    {
                        dep_firstName = Request.Form[i];
                    }
                    i++;
                    if (Request.Form.AllKeys[i].Contains("dep_LastName")) // indicates that the text boxes exist
                    {
                        int ParamStartPoint2 = Request.Form.AllKeys[i].IndexOf("dep_Last");
                        int ParamNameLength2 = Request.Form.AllKeys[i].Length - ParamStartPoint2 - 1;

                        string[] ControlName2 = Request.Form.AllKeys[i].Substring(ParamStartPoint2, ParamNameLength2).Split('$');

                        if (ControlName2[0] == "dep_LastName")
                        {
                            dep_lastName = Request.Form[i];
                        }
                    }
                    DependentObject newDependent = new DependentObject(dep_firstName, dep_lastName, newEmployee.getFullName());
                    newEmployee.addDependent(newDependent);
                }
            }
            BackendData.tracker.addEmployee(newEmployee);
            Response.Redirect("~/ViewEmployees.aspx");
        }

        protected void Button_ContinueAddingDependents_Click(object sender, EventArgs e)
        {
            Button_ContinueAddingDependents.Visible = false;
            TextBoxNumberOfDependents.ReadOnly = false;
            Button_GenerateDependentFields.Visible = true;
        }
    }
}