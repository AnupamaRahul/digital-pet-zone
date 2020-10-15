using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Documents_Salaryissue : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select * from employees");

            while (con.dr.Read())
            {

                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         try
        {
            con.dr = con.read("select count(*)from salaryissue");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string salaryid = "ISSOO" + count;
  con.dml("insert into salaryissue(issueid,employeeid,name,salaryamount,bonus,issuedate,accountno,month,year)values('" + salaryid + "','" + DropDownList1.SelectedItem.Text + "','" + txtnme.Text + "','" + txtsalary.Text + "','" + txtbonus.Text + "','" + DateTime.Now.ToShortDateString() + "','" + txtnum.Text + "','" + DropDownList2.SelectedItem.Text + "','" + txtyr.Text + "')");

            lblmsg.Text = "Successfully Registered";

            
        }

        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
 }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}