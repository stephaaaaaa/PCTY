﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BenefitsCalculation
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_AddDependent_Click(object sender, EventArgs e)
        {
            Panel_AddDependents.Visible = true;
        }
    }
}