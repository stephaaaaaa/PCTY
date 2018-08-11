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
        private int numberOfDependents;
        private Button submitEmployeeAndDependents;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Button_SubmitEmployeeAndDependents_Click(object sender, EventArgs e)
        {
            Response.Write("I've been clicked!");
        }

        protected void Button_AddDependent_Click(object sender, EventArgs e)
        {
            TextBox_EmployeeFirstName.ReadOnly = true;
            TextBox_EmployeeLastName.ReadOnly = true;
            Panel_AddDependents.Visible = true;
        }

        protected void Button_GenerateDependentFields_Click(object sender, EventArgs e)
        {
            numberOfDependents = int.Parse(TextBoxNumberOfDependents.Text);
            RequiredFieldValidator namesFieldValidtor = new RequiredFieldValidator();
            namesFieldValidtor.ErrorMessage = "Please enter a name.";
            namesFieldValidtor.ForeColor.Equals("#db1a32");

            Label[] fName_labels = new Label[numberOfDependents];

            TextBox[] fName_TextBoxes = new TextBox[numberOfDependents];

            Label[] lName_labels = new Label[numberOfDependents];
            TextBox[] lName_TextBoxes = new TextBox[numberOfDependents];

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
                fName_TextBoxes[i].CssClass = "form-control";
                namesFieldValidtor.ControlToValidate = fName_TextBoxes[i].Text;
                namesRegExValidator.ControlToValidate = fName_TextBoxes[i].Text;

                lName_labels[i] = new Label();
                lName_labels[i].CssClass = "row col-lg-2";
                lName_labels[i].Text = $"Dependent {i + 1} last name";


                lName_TextBoxes[i] = new TextBox();
                lName_TextBoxes[i].CssClass = "form-control";
                //namesFieldValidtor.ControlToValidate = lName_TextBoxes[i].Text;
                //namesRegExValidator.ControlToValidate = lName_TextBoxes[i].Text;

            }

            // This adds the controls to the form (you will need to specify co-ordinates etc. first)
            for (int i = 0; i < numberOfDependents; i++)
            {
                Panel_DependentsFields.Attributes.Add("class", "row");
                Panel_DependentsFields.Controls.Add(fName_labels[i]);
                Panel_DependentsFields.Controls.Add(fName_TextBoxes[i]);
                Panel_DependentsFields.Attributes.Add("class", "row");
                //Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
                Panel_DependentsFields.Controls.Add(lName_labels[i]);
                Panel_DependentsFields.Controls.Add(lName_TextBoxes[i]);
                Panel_DependentsFields.Attributes.Add("class", "row");
                //Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
                //Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
            }
            Panel_DependentsFields.CssClass = "row";
            Panel_DependentsFields.Visible = true;
            Panel_SubmitWithDependents.Visible=true;
        }

        protected void Button_SubmitEmployeeWithNoDependents_Click(object sender, EventArgs e)
        {
            string fname = TextBox_EmployeeFirstName.Text;
            string lname = TextBox_EmployeeLastName.Text;

            EmployeeObject newEmployee = new EmployeeObject(fname, lname, false);
            EmployeeData.tracker.addEmployee(newEmployee);
        }

        protected void Button_SubmitWithDependents_Click(object sender, EventArgs e)
        {
            Response.Write("clicked!");
        }
    }
}