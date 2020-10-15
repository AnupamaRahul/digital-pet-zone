using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VacanciesStatusUpdation : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        fillgrid();
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select vacancyid from vacancies where status='Open'");
            while (con.dr.Read())
            {
                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
        }
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from vacancies where vacancyid ='" + DropDownList1.SelectedItem.Text + "'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.dml("update vacancies set status='" + DropDownList2.SelectedItem.ToString() + "' where vacancyid='" + DropDownList1.SelectedItem.ToString() + "'");
        lblmsg.Text = "Updated";
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}