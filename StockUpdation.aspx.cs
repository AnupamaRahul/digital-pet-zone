using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockUpdation : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select productid from products ");

            while (con.dr.Read())
            {

                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
        }
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from products where productid='"+DropDownList1.SelectedItem.ToString()+"'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int quantity = Convert.ToInt16(txtqu.Text);
            con.dml("update products set rate='" + txrate.Text + "' , stockquantity=stockquantity +"+ quantity+ " where productid='" + DropDownList1.SelectedItem.Text + "'");
            lblmsg.Text = "Updated Successfully";
        }
        catch(Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
        Panel1.Visible = true;
    }
}