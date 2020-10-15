using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Vacancies : System.Web.UI.Page
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
            con.dr = con.read("select count(*)from vacancies");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string vacancyid = "VAC00" + count;
            con.dml("insert into vacancies(vacancyid,post,no_of_vacancies,basicqualification,submitdate,salaryrange,status,agelimit)values('" +vacancyid  + "','" + txtpost.Text + "','" + txtnof.Text + "','" + txtbq.Text + "','" + DateTime.Now.ToShortDateString() + "','"+txtsr.Text+"','Open','"+txtage.Text+"')");

            lblmsg.Text = "Successfully Saved and vacancy ID is '"+vacancyid+"' ";


        }
        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
}