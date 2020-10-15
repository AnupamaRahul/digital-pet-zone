using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Complaint : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.dr = con.read("select count(*)from complaints");
            int count = 0;
            if(con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string complaintID = "COMOO" + count;
            con.dml("insert into complaints(complaintid,username,subject,submitdate,complaintdeails)values('"+complaintID+"','" +Session["username"].ToString()+ "','" + txtsub.Text + "','" + System.DateTime.Now.ToShortDateString()+ "','" + txtcmp.Text + "')");
            lblmsg.Text = "Your Complaint Successfully Registered.Complaint ID is '"+complaintID+"'";
        }
        catch(Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
}