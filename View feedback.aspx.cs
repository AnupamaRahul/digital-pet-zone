using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_feedback : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from feedbacks").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    public void delete(object sender,CommandEventArgs e)
    {
        string msgid = e.CommandName.ToString();
        con.dml("delete from feedbacks where feedbackid='" + msgid + "'");
        Label1.Text = "";
        fillgrid();
    }
   
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Visible = true;
        Label1.Text = DataGrid1.SelectedItem.Cells[4].Text;
    }
}