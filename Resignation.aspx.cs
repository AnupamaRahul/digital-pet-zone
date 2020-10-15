using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Resignation : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
       
       
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from employees where enddate is null").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void btn_Click(object sender, EventArgs e)
    {
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.dml("delete from users where username='" + DataGrid1.SelectedItem.Cells[0].Text + "'");
            con.dml("update employees set enddate='" + DateTime.Now.ToShortDateString() + "'");
            con.dml("update employees set remarks='" + txtrsn.Text + "'");
        }
        catch(Exception ee)
        {
            Response.Write(ee.ToString());
        }

    }
}