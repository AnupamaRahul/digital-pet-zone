using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Feedback : System.Web.UI.Page
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
            con.dr = con.read("select count(*)from feedbacks");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string feedbackid = "FEEDO" + count;
           

            con.dml("insert into feedbacks(feedbackid,name,address,contactno,feedback)values('" + feedbackid + "','" + txtname.Text + "','" + txtadd.Text + "','" + txtcon.Text + "','" + txtfeed.Text + "')");

            lblmsg.Text = "Successfully Saved";


        }
        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
}