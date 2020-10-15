using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class viewvacancy : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from vacancies where status='Open'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["vacancyid"] = DataGrid1.SelectedItem.Cells[0].Text;
        Response.Redirect("Postresume.aspx");
    }
}