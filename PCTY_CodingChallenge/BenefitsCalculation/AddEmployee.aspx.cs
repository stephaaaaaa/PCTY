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

            TextBox[] textBoxes = new TextBox[numberOfDependents];
            Label[] labels = new Label[numberOfDependents];

            for (int i = 0; i < numberOfDependents; i++)
            {
                labels[i] = new Label();
                labels[i].CssClass = "col-lg-2";
                labels[i].Text = "Dependent name";
                // Here you can modify the value of the label which is at labels[i]

                textBoxes[i] = new TextBox();
                textBoxes[i].CssClass = "form-control";
                // Here you can modify the value of the textbox which is at textBoxes[i]

            }

            // This adds the controls to the form (you will need to specify thier co-ordinates etc. first)
            for (int i = 0; i < numberOfDependents; i++)
            {
                Panel_DependentsFields.Controls.Add(textBoxes[i]);
                Panel_DependentsFields.Controls.Add(labels[i]);
            }
            Panel_DependentsFields.Visible = true;
        }
    }
}