using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewCustomerRegistration : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
    }
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        con.dr = con.read("select * from users where username='" + txtUser.Text + "'");
        if(con.dr.Read())
        {
            lblcheck.Text = "Username already exist";
        }
        else
        {
            lblcheck.Text = "Username doesn't exist";
        }
    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        try
        {
            
            con.dml("insert into users values('" + txtUser.Text + "','" + txtPwd.Text + "','Customer')");
            lblMsg.Text = "Successfully Registered";


            con.dml("insert into customerregistration(username,fullname,address,gender,email,phone_number) values('"+txtUser.Text+"','"+txtFname.Text+"','"+txtAdd.Text+"','"+radGen.Text+"','"+txtEmail.Text+"','"+txtPhn.Text+"')");
            lblMsg.Text = "Successfully Registered";
        }
        catch(Exception ee)
        {
            lblMsg.Text = "Username already exist";
            Response.Write(ee.ToString());
        }
    }
}