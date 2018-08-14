using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class CloserDetails : System.Web.UI.Page
    {
        #region global vars
        int incomingEmployeeID = 0;
        Employee employeeToView = new Employee();
        List<Dependent> dependents = new List<Dependent>();
        List<Dependent> dependentBelongingToEmployee = new List<Dependent>();
        #endregion

        #region helper methods
        private int getIncomingEmployeeID()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("id="))
            {
                string[] urlPortion = url.Split('=');
                incomingEmployeeID = int.Parse(urlPortion[1]);
            }
            return incomingEmployeeID;
        }

        private double getCostAccruedByDependents()
        {
            double costAccrued = 0;
            foreach (Dependent dep in dependents)
            {
                if (dep.employeeID == employeeToView.employeeID)
                {
                    dependentBelongingToEmployee.Add(dep);
                    costAccrued += dep.cost;
                }
            }
            return costAccrued;
        }

        private TableHeaderRow initializeDependentsHeader()
        {
            TableHeaderCell lastNameHeader = new TableHeaderCell();
            lastNameHeader.Text = "Last Name";
            lastNameHeader.Attributes.Add("class", "text-center");
            TableHeaderCell firstNameHeader = new TableHeaderCell();
            firstNameHeader.Text = "First Name";
            firstNameHeader.Attributes.Add("class", "text-center");
            TableHeaderCell dependentCostHeader = new TableHeaderCell();
            dependentCostHeader.Text = "Cost";
            dependentCostHeader.Attributes.Add("class", "text-center");
            TableHeaderCell blankCell = new TableHeaderCell();
            TableHeaderCell blankCell2 = new TableHeaderCell();

            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(lastNameHeader);
            headerRow.Cells.Add(firstNameHeader);
            headerRow.Cells.Add(dependentCostHeader);
            headerRow.Cells.Add(blankCell);
            headerRow.Cells.Add(blankCell2);

            return headerRow;
        }

        private void initializePeopleLists()
        {
            using (var db = new BenefitsContext())
            {
                employeeToView = db.Employees.FirstOrDefault(p => p.employeeID == incomingEmployeeID);
                dependents = db.Dependents.ToList();
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeID = getIncomingEmployeeID();

            initializePeopleLists();

            if (employeeToView.hasDependent == true)
                CloserDetails_ForDependent.Visible = true;

            double costAccruedByDependents = getCostAccruedByDependents();

            Table dependentsDetail = new Table();
            TableHeaderRow headerRow = initializeDependentsHeader();
            dependentsDetail.Rows.Add(headerRow);

            foreach (Dependent dep in dependentBelongingToEmployee)
            {
                Button button_EditDependent = new Button();
                Button button_DeleteDependent = new Button();
                button_EditDependent.ID = $"{dep.id}_Edit";
                button_EditDependent.Text = "Edit";
                button_EditDependent.CssClass = "btn";
                button_DeleteDependent.ID = $"{dep.id}_Delete";
                button_DeleteDependent.CssClass = "btn btn-danger";
                button_DeleteDependent.Text = "Delete";

                TableCell lastCell = new TableCell();
                lastCell.Text = dep.lastName;
                TableCell firstCell = new TableCell();
                firstCell.Text = dep.firstName;
                TableCell dependentCost = new TableCell();
                dependentCost.Text = dep.cost.ToString("C2");
                TableCell buttonDelete = new TableCell();
                buttonDelete.Controls.Add(button_EditDependent);
                TableCell buttonEdit = new TableCell();
                buttonEdit.Controls.Add(button_DeleteDependent);

                TableRow newRow = new TableRow();
                newRow.Cells.Add(lastCell);
                newRow.Cells.Add(firstCell);
                newRow.Cells.Add(dependentCost);
                newRow.Cells.Add(buttonDelete);
                newRow.Cells.Add(buttonEdit);

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