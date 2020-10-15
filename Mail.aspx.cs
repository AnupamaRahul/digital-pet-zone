using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mail : System.Web.UI.Page
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
            con.dml("insert into mail(toaddress,fromaddress,subject,date,message,flag)values('"+txtto.Text+"','"+Session["username"]+"','"+txtsub.Text+"','"+DateTime.Now.ToShortDateString()+"','"+txtmsg.Text+"','Senditem')");
            lblmsg.Text = "Message Succesfully Send";
        }
        catch
        {  }
    }
}