using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderDelivery : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select * from ordermaster where status='Order'");

            while (con.dr.Read())
            {

                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());


            }
            con.dr.Close();

        }
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from orderdetails where orderproductno='"+DropDownList1.SelectedItem.ToString()+"'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.dml("update ordermaster set status ='Delivered' where orderproductno='"+DropDownList1.SelectedItem.ToString()+"'");
            lblmsg.Text = "Product Shipped";
        }
        catch(Exception ee)
        {
            Response.Write(ee.ToString());
        }
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
       int qua=Convert.ToInt16(DataGrid1.SelectedItem.Cells[2].Text);
       con.dml("update products set stockquantity=stockquantity-'"+qua+"' where productid='" +DataGrid1.SelectedItem.Cells[1].Text + "'");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    { 
       

        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        con.dr = con.read("select * from ordermaster where orderproductno='" + DropDownList1.SelectedItem.ToString() + "'");

        if (con.dr.Read())
        {

            lblcu.Text = con.dr.GetValue(4).ToString();
            lbladd.Text = con.dr.GetValue(5).ToString();
            lblno.Text = con.dr.GetValue(6).ToString();
            //fillgrid();

        }
        con.dr.Close();
    }
}
