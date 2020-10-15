using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Viewandreplycomplaint : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from complaints where replydate is null").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtcom.Visible = true;
        txtcom.Text = DataGrid1.SelectedItem.Cells[2].Text;

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        con.dml("update complaints set reply='" + txtrep.Text + "' ,replydate='" + DateTime.Now.ToShortDateString() + "'where complaintid='" + DataGrid1.SelectedItem.Cells[0].Text + "'");
        lblmsg.Text = "Complaint Reply Successfull";
    }
}