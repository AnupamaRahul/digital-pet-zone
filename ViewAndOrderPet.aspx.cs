using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewAndOrderPet : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
        
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from petdetails where status='available' ").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible=true;
       
    }
    public void delete(object sender, CommandEventArgs e)
    {
        Image1.Visible = true;
        Image1.ImageUrl = DataGrid1.SelectedItem.Cells[8].Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
         con.dr = con.read("select count(*)from orderpet");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
            string orderid = "ORD" + count;
        con.dml("insert into orderpet values('"+orderid+"','"+Session["username"].ToString()+"','"+DataGrid1.SelectedItem.Cells[0].Text+"','"+DateTime.Now.ToShortDateString()+"','"+txtcust.Text+"','"+txtnum.Text+"','"+txtship.Text+"','Booked')");
       lblmsg.Text="Your Order ID is '"+orderid+"'";
        }
        catch(Exception ee)
        {
           // Response.Write(ee.ToString());
        }
    }
}