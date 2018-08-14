using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class ViewEmployees : System.Web.UI.Page
    {
        string sortingChoice;
        List<Employee> employeesInDB = new List<Employee>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int numberOfDataPopulatedRows = 0;

            using (var db = new BenefitsContext())
            {
                employeesInDB = db.Employees.OrderByDescending(p => p.employeeID).ToList();
            }

            #region Cases for dropdown menu changes
            if (DropDown_SortingOptions.Text.Equals("Newest"))
            {
                using (var db = new BenefitsContext())
                {
                    employeesInDB = db.Employees.OrderByDescending(p => p.employeeID).ToList();
                }
            }
            else if (DropDown_SortingOptions.Text.Equals("Oldest"))
            {
                using (var db = new BenefitsContext())
                {
                    employeesInDB = db.Employees.OrderBy(p => p.employeeID).ToList();
                }
            }
            else if (DropDown_SortingOptions.Text.Equals("Last name"))
            {
                using (var db = new BenefitsContext())
                {
                    employeesInDB = db.Employees.OrderBy(p => p.lastName).ToList();
                }
            }
            else if (DropDown_SortingOptions.Text.Equals("First name"))
            {
                using (var db = new BenefitsContext())
                {
                    employeesInDB = db.Employees.OrderBy(p => p.firstName).ToList();
                }
            }
            else if (DropDown_SortingOptions.Text.Equals("Dependents (high to low)"))
            {
                using (var db = new BenefitsContext())
                {
                    employeesInDB = db.Employees.OrderByDescending(p => p.Dependents.Count).ToList();
                }
            }
            else if (DropDown_SortingOptions.Text.Equals("Dependents (low to high)"))
            {
                using (var db = new BenefitsContext())
                {
                    employeesInDB = db.Employees.OrderBy(p => p.Dependents.Count).ToList();
                }
            }
            #endregion

            foreach (Employee emp in employeesInDB)
            {
                TableCell idCell = new TableCell();
                TableCell lastCell = new TableCell();
                TableCell firstCell = new TableCell();
                TableCell depNumCell = new TableCell();
                TableCell costPerYearCell = new TableCell();
                TableCell paycheckDeductionCell = new TableCell();
                TableCell amountPerPaycheckCell = new TableCell();
                TableCell viewDetailsButtonCell = new TableCell();

                idCell.Text = emp.employeeNumber.ToString();
                lastCell.Text = emp.lastName;
                firstCell.Text = emp.firstName;
                List<Dependent> dependentsInDB = new List<Dependent>();
                int dependentsCount = 0;
                using (var db = new BenefitsContext())
                {
                    dependentsInDB = db.Dependents.ToList();
                }
                foreach (Dependent dependent in dependentsInDB)
                {
                    if (dependent.employeeID == emp.employeeID)
                    {
                        dependentsCount++;
                    }
                }

                depNumCell.Text = dependentsCount.ToString();
                costPerYearCell.Text = emp.cost.ToString("C2");
                amountPerPaycheckCell.Text = emp.paycheckAfterDeductions.ToString("C2");
                paycheckDeductionCell.Text = emp.deductionsPerPaycheck.ToString("C2");

                Button Button_ViewDetails = new Button();
                Button_ViewDetails.Text = "View Details";
                Button_ViewDetails.CssClass = "btn";
                Button_ViewDetails.Click += new EventHandler(Button_ViewDetails_Click);
                viewDetailsButtonCell.Controls.Add(Button_ViewDetails);

                TableRow row = new TableRow();

                row.Cells.Add(idCell);
                row.Cells.Add(lastCell);
                row.Cells.Add(firstCell);
                row.Cells.Add(depNumCell);
                row.Cells.Add(costPerYearCell);
                row.Cells.Add(paycheckDeductionCell);
                row.Cells.Add(amountPerPaycheckCell);
                row.Cells.Add(viewDetailsButtonCell);

                Table_EmployeeView.Rows.Add(row);
                numberOfDataPopulatedRows++;
            }
            if (numberOfDataPopulatedRows > 1)
            {
                sortingButtonsPanel.Visible = true;
            }
        }

        private void Button_ViewDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CloserDetails");
        }
    }
}