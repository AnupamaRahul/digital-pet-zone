using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salaryreport : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select year,month from salaryissue");
            while (con.dr.Read())
            {
                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
                DropDownList2.Items.Add(con.dr.GetValue(1).ToString());
            }
            con.dr.Close();

        }
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        fillgrid();
    }
    public void fillgrid()
    {
        DataGrid1.Visible = true;
        DataGrid1.DataSource = con.fill("select * from salaryissue where year = '" + DropDownList1.SelectedItem.ToString() + "' and month='" + DropDownList2.SelectedItem.ToString() + "'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }


    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}