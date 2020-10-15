using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Changepassword : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
    }
   
    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            con.dr = con.read("select * from users where username ='" + Session["username"].ToString() + "'and password='" + txtOld.Text + "'");
            if (con.dr.Read())
            {
                con.dr.Close();
                con.dml("update users set password='" + txtNew.Text + "'where username='" + Session["username"].ToString() + "'and password='" + txtOld.Text + "'");
                lblMsg.Text = "updated";
            }
            else
            {
                con.dr.Close();
                lblMsg.Text = "invalid password";
            }
        }
        catch (Exception ee)
        {
            lblMsg.Text = "failed";
            Response.Write(ee.ToString());
        }
    }
}