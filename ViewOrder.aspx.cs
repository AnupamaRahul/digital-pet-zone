using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewOrder : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
       
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select orderno from orderpet where status='Booked' ");

            while (con.dr.Read())
            {

                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
        }
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from orderpet where orderno='"+DropDownList1.SelectedItem.ToString()+"'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.dml("update orderpet set status='Delivered' where orderno='" + DataGrid1.SelectedItem.Cells[0].Text + "'");
    }
}