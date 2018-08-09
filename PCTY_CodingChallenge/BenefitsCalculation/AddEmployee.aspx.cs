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

        protected void Page_Load(object sender, EventArgs e)
        {
            
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

            Label[] fName_labels = new Label[numberOfDependents];
            TextBox[] fName_TextBoxes = new TextBox[numberOfDependents];

            Label[] lName_labels = new Label[numberOfDependents];
            TextBox[] lName_TextBoxes = new TextBox[numberOfDependents];

            for (int i = 0; i < numberOfDependents; i++)
            {
                fName_labels[i] = new Label();
                fName_labels[i].CssClass = "col-lg-2";
                fName_labels[i].Text = $"Dependent {i+1} first name";

                fName_TextBoxes[i] = new TextBox();
                fName_TextBoxes[i].CssClass = "form-control";

                lName_labels[i] = new Label();
                lName_labels[i].CssClass = "col-lg-2";
                lName_labels[i].Text = $"Dependent {i+1} last name";
                
                lName_TextBoxes[i] = new TextBox();
                lName_TextBoxes[i].CssClass = "form-control";

            }

            // This adds the controls to the form (you will need to specify co-ordinates etc. first)
            for (int i = 0; i < numberOfDependents; i++)
            {
                //Panel_DependentsFields.Attributes.Add("class", "row");
                Panel_DependentsFields.Controls.Add(fName_labels[i]);
                Panel_DependentsFields.Controls.Add(fName_TextBoxes[i]);
                Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
                Panel_DependentsFields.Controls.Add(lName_labels[i]);
                Panel_DependentsFields.Controls.Add(lName_TextBoxes[i]);
                Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
                Panel_DependentsFields.Controls.Add(new LiteralControl("<br />"));
            }
            Panel_DependentsFields.Visible = true;
        }
    }
}