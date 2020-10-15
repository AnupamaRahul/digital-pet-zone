using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Back : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string usertype= Session["utype"].ToString();
        if (usertype.Equals("Admin"))
        {
            Response.Redirect("Adminarea.aspx");
        }
        else if (usertype.Equals("Employee"))
        {
            Response.Redirect("Employeearea.aspx");
        }
        else if (usertype.Equals("Customer"))
        {
            Response.Redirect("Customerarea.aspx");
        }
    }
}