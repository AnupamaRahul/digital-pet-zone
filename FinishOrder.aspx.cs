using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FinishOrder : System.Web.UI.Page
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
          //  con.dr = con.read("select count(*)from ordermaster");
          //  int count = 0;
            //if (con.dr.Read())
            //{
              //  count = Convert.ToInt32(con.dr.GetValue(0).ToString());
          //  }
   //         con.dr.Close();
     //       count++;
       //     string cusid = "cus" + count;
            con.dml("insert into ordermaster values('" + Session["orderpet"].ToString() + "','" + Session["username"].ToString() + "','" + DateTime.Now.ToShortDateString() + "','" + Session["total"].ToString() + "','" + txtcu.Text + "','" + txtdel.Text + "','" + txtno.Text + "','Order')");
            lblmsg.Text = "Successfull";
        }
        catch(Exception ee)
        {
            Response.Write(ee.ToString());
        }
    }
}