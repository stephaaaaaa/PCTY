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
        private void getIncomingEmployeeID()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            if (url.Contains("id="))
            {
                string[] urlPortion = url.Split('=');
                incomingEmployeeID = int.Parse(urlPortion[1]);
            }
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

        private void initializeDependentButtons(Dependent dep, Button button_EditDependent, Button button_DeleteDependent)
        {
            button_EditDependent.ID = $"Edit_{dep.id}";
            button_EditDependent.Text = "Edit";
            button_EditDependent.CssClass = "btn";
            button_EditDependent.Click += new EventHandler(button_EditDependent_Click);

            button_DeleteDependent.ID = $"Delete_{dep.id}";
            button_DeleteDependent.CssClass = "btn btn-danger";
            button_DeleteDependent.Text = "Delete";
            button_DeleteDependent.Click += new EventHandler(button_DeleteDependent_Click);

        }

        private void initializeProviderLabels(double costAccruedByDependents)
        {
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            getIncomingEmployeeID();
            initializePeopleLists();
            CloserDetails_ForDependent.Visible = true;

            button_EditEmployee.ID = $"buttonEditEmployee_{incomingEmployeeID}";
            button_DeleteEmployee.ID = $"buttonDeleteEmployee_{incomingEmployeeID}";

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

                initializeDependentButtons(dep, button_EditDependent, button_DeleteDependent);

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

            initializeProviderLabels(costAccruedByDependents);
        }

        private void button_DeleteDependent_Click(object sender, EventArgs e)
        {
            string[] buttonIDComponents = new string[0];
            int dependentToDelete_ID = 0;
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("Delete"))
                {
                    string buttonNumber = Request.Form.AllKeys[i];
                    buttonIDComponents = buttonNumber.Split('_');
                    dependentToDelete_ID = int.Parse(buttonIDComponents[1]);
                }
            }

            using (var db = new BenefitsContext())
            {
                Dependent toDelete = db.Dependents.FirstOrDefault(p => p.id == dependentToDelete_ID);
                Employee toUpdate = db.Employees.First(p => p.employeeID == incomingEmployeeID);

                foreach (Dependent d in dependentBelongingToEmployee)
                {
                    if (d.id == toDelete.id)
                    {
                        dependentBelongingToEmployee.Remove(d);
                        break;
                    }
                }
                if (dependentBelongingToEmployee.Count < 1)
                    toUpdate.hasDependent = false;

                toUpdate.cost -= toDelete.cost;
                toUpdate.deductionsPerPaycheck = toUpdate.cost / 26;
                toUpdate.paycheckAfterDeductions = toUpdate.paycheckBeforeDeductions - toUpdate.deductionsPerPaycheck;

                db.Dependents.Remove(toDelete);
                db.SaveChanges();
            }
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }

        private void button_EditDependent_Click(object sender, EventArgs e)
        {
            string[] buttonIDComponents = new string[0];
            int dependentToEdit_ID = 0;
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("Edit"))
                {
                    string buttonNumber = Request.Form.AllKeys[i];
                    buttonIDComponents = buttonNumber.Split('_');
                    dependentToEdit_ID = int.Parse(buttonIDComponents[1]);
                }
            }
            Response.Redirect($"EditPerson.aspx?id=d_{dependentToEdit_ID}");
        }

        protected void button_DeleteEmployee_Click(object sender, EventArgs e)
        {
            string[] buttonIDComponents = new string[0];
            int employeeToDelete_ID = 0;
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("Delete"))
                {
                    string buttonNumber = Request.Form.AllKeys[i];
                    buttonIDComponents = buttonNumber.Split('_');
                    employeeToDelete_ID = int.Parse(buttonIDComponents[1]);
                }
            }
            using (var db = new BenefitsContext())
            {
                Employee toDelete = db.Employees.FirstOrDefault(p => p.employeeID == employeeToDelete_ID);
                foreach (Dependent d in dependentBelongingToEmployee)
                {
                    Dependent dependentToDelete = db.Dependents.FirstOrDefault(p => p.id == d.id);
                    db.Dependents.Remove(dependentToDelete);
                }
                db.Employees.Remove(toDelete);
                db.SaveChanges();
            }
            Response.Redirect($"ViewEmployees");
        }

        protected void button_EditEmployee_Click(object sender, EventArgs e)
        {
            string[] buttonIDComponents = new string[0];
            int dependentToEdit_ID = 0;
            for (int i = 0; i < Request.Form.Count; i++)
            {
                if (Request.Form.AllKeys[i].Contains("Edit"))
                {
                    string buttonNumber = Request.Form.AllKeys[i];
                    buttonIDComponents = buttonNumber.Split('_');
                    dependentToEdit_ID = int.Parse(buttonIDComponents[1]);
                }
            }
            Response.Redirect($"EditPerson.aspx?id=e_{dependentToEdit_ID}");
        }

        protected void button_AddDependent_Click(object sender, EventArgs e)
        {
            Response.Redirect($"AddEmployee.aspx?id=e_{incomingEmployeeID}");

        }
    }
}