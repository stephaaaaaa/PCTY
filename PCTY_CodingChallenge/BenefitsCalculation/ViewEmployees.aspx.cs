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
        protected void Page_Load(object sender, EventArgs e)
        {
            int numberOfDataPopulatedRows = 0;
            List<Employee> employeesInDB;

            using (var db = new BenefitsContext())
            {
                employeesInDB = db.Employees.ToList();
            }

            foreach (Employee emp in employeesInDB)
            {
                TableCell idCell = new TableCell();
                TableCell lastCell = new TableCell();
                TableCell firstCell = new TableCell();
                TableCell depNumCell = new TableCell();
                TableCell costPerYearCell = new TableCell();
                TableCell paycheckDeductionCell = new TableCell();
                TableCell amountPerPaycheckCell = new TableCell();
                TableCell buttonCell = new TableCell();

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
                    if (dependent.Employee.id == emp.id)
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
                buttonCell.Controls.Add(Button_ViewDetails);

                TableRow row = new TableRow();

                row.Cells.Add(idCell);
                row.Cells.Add(lastCell);
                row.Cells.Add(firstCell);
                row.Cells.Add(depNumCell);
                row.Cells.Add(costPerYearCell);
                row.Cells.Add(paycheckDeductionCell);
                row.Cells.Add(amountPerPaycheckCell);
                row.Cells.Add(buttonCell);

                Table_EmployeeView.Rows.Add(row);
                numberOfDataPopulatedRows++;
            }
        }

        private void Button_ViewDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CloserDetails");
        }
    }
}