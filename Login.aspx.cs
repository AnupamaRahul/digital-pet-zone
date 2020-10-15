using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string usertype = "";
        con.dr = con.read("select * from users where username='" + txtusern.Text + "' and password='" + txtpwd.Text + "'");
        if(con.dr.Read())
        {
            Session["username"] = txtusern.Text;
            usertype = con.dr.GetValue(2).ToString();
            Session["utype"] = usertype;
            if(usertype.Equals("Admin"))
            {
                Response.Redirect("Adminarea.aspx");
            }
            else if(usertype.Equals("Employee"))
            {
                Response.Redirect("Employeearea.aspx");
            }
            else if(usertype.Equals("Customer"))
            {
                Response.Redirect("Customerarea.aspx");
            }
        }
        else
        {
            lblmsg.Text = "Invalid password";
        }
        con.dr.Close();
    }
}