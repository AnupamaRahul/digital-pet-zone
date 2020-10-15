using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Postresume : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();

        lblid.Text = Session["vacancyid"].ToString();
    }
   

    protected void btnsub_Click1(object sender, EventArgs e)
    {
       




      string resumeid = "";
        string ext = "", ext1 = "", src = "", src1 = "";
        string filename = "";
        try
        {
            con.dr = con.read("select count(*)from postresume");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
             resumeid = "RESOO" + count;


 filename = FileUpload1.PostedFile.FileName;
            if (FileUpload1.PostedFile.FileName.Length != 0)
            {
                ext = filename.Substring(filename.Length - 3);
                ext = ext.ToUpper();
                ext1 = filename.Substring(filename.Length - 4);
                ext1 = ext1.ToUpper();
                if (ext == "PDF")
                {
                    src = Server.MapPath("Documents") + "/" + resumeid + ".PDF";
                    FileUpload1.PostedFile.SaveAs(src);
                    src1 = "~/Documents/" + resumeid + ".PDF";
                }
                else if (ext1 == "DOCX")
                {
                    src = Server.MapPath("Documents") + "/" + resumeid + ".DOCX";
                    FileUpload1.PostedFile.SaveAs(src);
                    src1 = "~/Documents/" + resumeid + ".DOCX";
                }
            
            else
            {
            }

        }}


        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }

   try
        {

            con.dml("insert into postresume(resumeid,vacancyid,name,gender,dob,address,mobile,qualification,resume)values('" + resumeid + "','" + Session["vacancyid"].ToString() + "','" + txtname.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + txtdob.Text + "','" + txtadd.Text + "','" + txtmob.Text + "','" + txtqual.Text + "','" + src1 + "')");

            lblmsg.Text = "Successfully Registered";


        }
        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }
    
    }
}
