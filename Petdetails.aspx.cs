using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Petdetails : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string petid = "";
        string ext = "", ext1 = "", src = "", src1 = "";
        string filename = "";
        try
        {
            con.dr = con.read("select count(*)from petdetails");
            int count = 0;
            if (con.dr.Read())
            {
                count = Convert.ToInt32(con.dr.GetValue(0).ToString());
            }
            con.dr.Close();
            count++;
             petid = "PETOO" + count;







            filename = FileUpload1.PostedFile.FileName;
            if (FileUpload1.PostedFile.FileName.Length != 0)
            {
                ext = filename.Substring(filename.Length - 3);
                ext = ext.ToUpper();
                ext1 = filename.Substring(filename.Length - 4);
                ext1 = ext1.ToUpper();
                if (ext == "JPG")
                {
                    src = Server.MapPath("Pics") + "/" + petid + ".JPG";
                    FileUpload1.PostedFile.SaveAs(src);
                    src1 = "~/Pics/" + petid + ".JPG";
                }
                else if (ext1 == "JPEG")
                {
                    src = Server.MapPath("Pics") + "/" + petid + ".JPEG";
                    FileUpload1.PostedFile.SaveAs(src);
                    src1 = "~/Pics/" + petid + ".JPEG";
                }
                else
                { }
            }
        }


        catch (Exception ee)
        {
            lblmsg.Text = "Failed";
            Response.Write(ee.ToString());
        }



























         try
        {
           
            con.dml("insert into petdetails(petid,breed,price,categories,gender,age,submitdate,status,image)values('" + petid + "','" + txtbreed.Text + "','" + txtprice.Text + "','"+txtcat.Text+"','" + RadioButtonList1.SelectedItem.Text + "','"+txtage.Text+"','"+DateTime.Now.ToShortDateString()+"','Available','"+src1+"')");

            lblmsg.Text = "Successfully Added";


        }
         catch (Exception ee)
         {
             lblmsg.Text = "Failed";
             Response.Write(ee.ToString());
         }
    }
}