using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServiceRequest : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        lblid.Text = Session["username"].ToString();
  //      con.dr = con.read("select * from customerregistration ");
        //
   //     while (con.dr.Read())
     //   {

       //     DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
        //}
        //con.dr.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.dr = con.read("select count(*)from servicerequest");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string shopid = "SH00" + count;
            con.dml("insert into servicerequest(requestid,customerid,location,servicetype,breed,requirements,requireddate,contactnumber)values('" + shopid + "','" + Session["username"].ToString() + "','" + txtlc.Text + "','" + txtser.Text + "','" + txtbreed.Text + "','" + txtreq.Text + "','" + txtreqq.Text + "','" + txtcon.Text + "')");

            lblmsg.Text = "Successfully Registered";
        }
        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
}