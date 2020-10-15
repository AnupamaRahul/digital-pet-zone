using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Complaintstatus : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        if(!Page.IsPostBack)
        {
            con.dr = con.read("select complaintid from complaints where username='" + Session["username"].ToString() + "'and reply is not null");
        while (con.dr.Read())
        {

            DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
        }
        con.dr.Close();}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        con.dr = con.read("select * from complaints where complaintid='" +DropDownList1.SelectedItem.Text+ "' and username='" + Session["username"].ToString() + "'");
        if (con.dr.Read())
        {
            txtcomp.Text = con.dr.GetValue(5).ToString();
            lblcmp.Visible = true;
            txtcomp.Visible = true;
            con.dr.Close();
        }
    }
}