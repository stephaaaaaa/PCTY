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

            foreach (EmployeeObject emp in BackendData.tracker.viewEmployees())
            {
                TableCell idCell = new TableCell();
                TableCell lastCell = new TableCell();
                TableCell firstCell = new TableCell();
                TableCell depNumCell = new TableCell();
                TableCell costPerYearCell = new TableCell();
                TableCell paycheckDeductionCell = new TableCell();
                TableCell amountPerPaycheckCell = new TableCell();
                TableCell buttonCell = new TableCell();

                idCell.Text = emp.getID();
                lastCell.Text = emp.getLastName();
                firstCell.Text = emp.getFirstName();
                depNumCell.Text = emp.getDependentsCount().ToString();
                costPerYearCell.Text = emp.getCost();
                amountPerPaycheckCell.Text = emp.getPaycheckAfterDeductions();
                paycheckDeductionCell.Text = emp.getDeductionsPerPaycheck();

                Button Button_ViewDetails = new Button();
                Button_ViewDetails.Text = "View Details";
                Button_ViewDetails.CssClass = "btn";
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
    }
}