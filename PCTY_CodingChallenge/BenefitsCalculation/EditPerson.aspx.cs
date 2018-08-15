using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class EditPerson : System.Web.UI.Page
    {
        int incomingPersonID;
        bool isEmployee;
        bool isDependent;

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

        private void loadCorrectPanel()
        {
            if (isDependent)
                panel_editDependent.Visible = true;
            else if (isEmployee)
                panel_editEmployee.Visible = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getIncomingPersonID();
            loadCorrectPanel();

            if (isEmployee)
            {
                Employee empToEdit = new Employee();
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
                Dependent depToEdit = new Dependent();
                using (var db = new BenefitsContext())
                {
                    depToEdit = db.Dependents.FirstOrDefault(p => p.id == incomingPersonID);
                }
                label_dependentBeingEdited.Text = $"Currently editing: {depToEdit.firstName} {depToEdit.lastName}";
                textBox_dependentFName.Text = depToEdit.firstName;
                textBox_DependentLName.Text = depToEdit.lastName;
            }

        }
    }
}