using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductShopping : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        if(!Page.IsPostBack)
        { 
        con.dr = con.read("select count(*)from orderdetails");
        int count = 0;
        if (con.dr.Read())
        {
            count = Convert.ToInt32(con.dr.GetValue(0).ToString());
        }
        con.dr.Close();
        count++;

        Session["orderpet"] = "ORD" + count;
    }
        fillgrid();
       
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from products").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    public void fillgrid1()
    {
        DataGrid2.DataSource = con.fill("select * from orderdetails where orderproductno='"+Session["orderpet"].ToString()+"'").Tables[0].DefaultView;
        DataGrid2.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("FinishOrder.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        try
        {
           
            int p = Convert.ToInt16(DataGrid1.SelectedItem.Cells[5].Text);
            int q = Convert.ToInt16(txtq.Text);
            int  tot = p * q;
            Session["total"] = tot;
            con.dml("insert into orderdetails(orderproductno,productid,quantity,price) values('" + Session["orderpet"].ToString() + "','" + DataGrid1.SelectedItem.Cells[0].Text + "','" + txtq.Text + "','" + Session["total"] .ToString()+ "')");
            fillgrid1();
            totalAmt();

        }
        catch(Exception ee)
        {
            Response.Write(ee.ToString());
        }
    }

   

    protected void DataGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.dml("delete from orderdetails where productid='"+DataGrid2.SelectedItem.Cells[0].Text+"' and orderproductno='"+Session["orderpet"].ToString()+"'");
        totalAmt();
        fillgrid1();

    }
    public void totalAmt()
    {
        con.dr = con.read("select sum(price) from orderdetails where orderproductno='"+Session["orderpet"].ToString()+"'");
       
        if (con.dr.Read())
        {
            lbltot.Text=con.dr.GetValue(0).ToString();
        }
        con.dr.Close();
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}