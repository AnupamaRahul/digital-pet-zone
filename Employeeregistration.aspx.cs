using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employeeregistration : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
       
    }
    protected void btnreg_Click(object sender, EventArgs e)
    {
        try
        {
           
            con.dml("insert into users values('" + txtid.Text + "','" + txtid.Text + "','Employee')");

            con.dml("insert into employees(employeeid,name,gender,dob,email,address,mobile,qualification,designation,salary,startdate)values('"+txtid.Text+"','" + txtname.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtdob.Text + "','" + txtemail.Text + "','" + txtadd.Text + "','" + txtmob.Text + "','" + txtqual.Text + "','" + txtdesi.Text + "','" + txtsal.Text +"','"+DateTime.Now.ToShortDateString()+"')");
            
            lblMsg.Text = "Successfully Registered";


        }
        catch(Exception ee)
        {
            lblMsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
}