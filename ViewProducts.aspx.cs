using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewProducts : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
    }

    public void fillgrid()
    {
        DataGrid2.DataSource = con.fill("select * from products").Tables[0].DefaultView;
        DataGrid2.DataBind();
    }

    protected void DataGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}