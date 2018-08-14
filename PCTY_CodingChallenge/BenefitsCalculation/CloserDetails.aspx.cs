using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class CloserDetails : System.Web.UI.Page
    {
        Employee employeeToView = new Employee();
        List<Dependent> dependents = new List<Dependent>();
        List<Dependent> dependentBelongingToEmployee = new List<Dependent>();

        private int getIncomingEmployeeID()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            int employeeID = 0;
            if (url.Contains("id="))
            {
                string[] urlPortion = url.Split('=');
                employeeID = int.Parse(urlPortion[1]);
            }
            return employeeID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeID = getIncomingEmployeeID();

            using (var db = new BenefitsContext())
            {
                employeeToView = db.Employees.FirstOrDefault(p => p.employeeID == employeeID);
                dependents = db.Dependents.ToList();
            }

            if (employeeToView.hasDependent == true)
            {
                CloserDetails_ForDependent.Visible = true;
            }

            double costAccruedByDependents = 0;
            foreach (Dependent dep in dependents)
            {
                if (dep.employeeID == employeeToView.employeeID)
                {
                    dependentBelongingToEmployee.Add(dep);
                    costAccruedByDependents += dep.cost;
                }
            }

            Table dependentsDetail = new Table();
            TableHeaderCell lastNameHeader = new TableHeaderCell();
            lastNameHeader.Text = "Last Name";
            lastNameHeader.Attributes.Add("class", "text-center");
            TableHeaderCell firstNameHeader = new TableHeaderCell();
            firstNameHeader.Text = "First Name";
            firstNameHeader.Attributes.Add("class", "text-center");
            TableHeaderCell dependentCostHeader = new TableHeaderCell();
            dependentCostHeader.Text = "Cost";
            dependentCostHeader.Attributes.Add("class", "text-center");

            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(lastNameHeader);
            headerRow.Cells.Add(firstNameHeader);
            headerRow.Cells.Add(dependentCostHeader);
            dependentsDetail.Rows.Add(headerRow);
            foreach (Dependent dep in dependentBelongingToEmployee)
            {

                TableCell lastCell = new TableCell();
                lastCell.Text = dep.lastName;
                TableCell firstCell = new TableCell();
                firstCell.Text = dep.firstName;
                TableCell dependentCost = new TableCell();
                dependentCost.Text = dep.cost.ToString("C2");

                TableRow newRow = new TableRow();
                newRow.Cells.Add(lastCell);
                newRow.Cells.Add(firstCell);
                newRow.Cells.Add(dependentCost);

                dependentsDetail.Rows.Add(newRow);
            }
            dependentsDetail.Attributes.Add("class", "table custom-table table-hover");
            CloserDetails_ForDependent.Controls.Add(dependentsDetail);

            LabelEmployeeFullName.Text = $"{employeeToView.firstName} {employeeToView.lastName}";
            LabelEmployeeNumber.Text = $"{employeeToView.employeeNumber}";
            LabelBenefitsCost.Text = $"{employeeToView.cost.ToString("C2")}";
            LabelNumOfDependents.Text = $"{dependentBelongingToEmployee.Count}";
            LabelEmployeeSalary.Text = $"{employeeToView.paycheckBeforeDeductions.ToString("C2")}";
            LabelAmountIncreasedByDependents.Text = $"{costAccruedByDependents.ToString("C2")}";
            LabelDeductionsPerPaycheck.Text = $"{employeeToView.deductionsPerPaycheck.ToString("C2")}";
            LabelAfterDeductions.Text = $"{employeeToView.paycheckAfterDeductions.ToString("C2")}";
            LabelEmployeeBaseCost.Text = $"{(employeeToView.cost - costAccruedByDependents).ToString("C2")}";
        }
    }
}