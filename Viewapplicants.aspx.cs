using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Viewapplicants : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
        if (!Page.IsPostBack)
        {
            con.dr = con.read("select vacancyid from postresume");
            while (con.dr.Read())
            {
                DropDownList1.Items.Add(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
        }
    }
    public void fillgrid()
    {
        DataGrid1.DataSource = con.fill("select * from postresume where vacancyid='"+DropDownList1.SelectedItem.Text+"'").Tables[0].DefaultView;
        DataGrid1.DataBind();
    }

    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //string project_file="";
            string project_id = DataGrid1.SelectedItem.Cells[0].ToString();

            //SqlDataReader dr = con.read("select resume from postresume where resumeid='" + project_id + "'");
            //if(dr.Read())
            //{
              //  project_file=dr.GetValue()
            //}
        
            FileInfo file = new FileInfo(project_id);
            Response.AddHeader("Content-Disposition", "attachment;filename=" + file.Name);
            Response.TransmitFile(file.FullName);
            Response.WriteFile(project_id);
            Response.End();
        }
    
    catch(Exception ee)
        {
            Response.Write(ee.ToString());
    }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrid();
    }
}