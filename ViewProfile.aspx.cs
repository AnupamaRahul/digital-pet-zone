using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProfile : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
    }
   
    public void fillgrid()
    {
        DetailsView1.DataSource = con.fill("select * from customerregistration where username='"+Session["username"].ToString()+"'").Tables[0].DefaultView;
        DetailsView1.DataBind();
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
}