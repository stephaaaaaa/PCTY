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
            foreach (EmployeeObject emp in PeopleData.tracker.viewEmployees())
            {
                TableCell idCell = new TableCell();
                TableCell lastCell = new TableCell();
                TableCell firstCell = new TableCell();
                TableCell depNumCell = new TableCell();
                TableCell costPerYearCell = new TableCell();
                TableCell paycheckDeductionCell = new TableCell();

                idCell.Text = emp.getID();
                lastCell.Text = emp.getLastName();
                firstCell.Text = emp.getFirstName();
                depNumCell.Text = emp.getDependentsCount().ToString();
                costPerYearCell.Text = emp.getCost();
                paycheckDeductionCell.Text = "$0";

                TableRow row = new TableRow();
                row.Cells.Add(idCell);
                row.Cells.Add(lastCell);
                row.Cells.Add(firstCell);
                row.Cells.Add(depNumCell);
                row.Cells.Add(costPerYearCell);
                row.Cells.Add(paycheckDeductionCell);

                Table_EmployeeView.Rows.Add(row);
            }

        }
    }
}