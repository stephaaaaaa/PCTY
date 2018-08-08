using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Click_ViewEmployees(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewEmployees");
        }

        protected void Click_ModifyEmployees(object sender, EventArgs e)
        {
            Response.Redirect("~/ModifyEmployee");
        }

        protected void Click_AddEmployee(object sender, EventArgs e)
        {
            Response.Redirect("~/AddEmployee");
        }
    }
}