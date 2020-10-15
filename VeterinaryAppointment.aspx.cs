using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeterinaryAppointment : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();

        lblid.Text = Session["username"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.dr = con.read("select count(*)from veterinery_appointment");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string apoint = "AP00" + count;
            con.dml("insert into veterinery_appointment(requestid,customerid,submitdate,name,petname,phone,email,address,reason_for_appointment,prefereddate,time,gender,breed,age)values('" + apoint + "','" + Session["username"].ToString() + "','" +DateTime.Now.ToShortDateString()+ "','" + txtname.Text + "','" + txtpet.Text + "','" + txtphn.Text + "','" + txtemail.Text + "','" + txtadd.Text + "','" + txtreason.Text + "','" + txtdate.Text + "','" + txttime.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtbreed.Text + "','" + txtage.Text + "')");

            lblmsg.Text = "Successfully Booked Appointment";
        }
        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
}