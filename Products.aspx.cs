using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    connect con = new connect();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.start();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string productid="";
            string ext = "", ext1 = "", src = "", src1 = "";
            string filename = "";
            try
            {
                con.dr = con.read("select count(*)from products");
                int count = 0;
                if (con.dr.Read())
                {
                    count = Convert.ToInt32(con.dr.GetValue(0).ToString());
                }
                con.dr.Close();
                count++;
                 productid = "PROD" + count;


              




                filename = FileUpload1.PostedFile.FileName;
                if (FileUpload1.PostedFile.FileName.Length != 0)
                {
                    ext = filename.Substring(filename.Length - 3);
                    ext = ext.ToUpper();
                    ext1 = filename.Substring(filename.Length - 4);
                    ext1 = ext1.ToUpper();
                    if (ext == "JPG")
                    {
                        src = Server.MapPath("Pics") +"/"+ productid + ".JPG";
                        FileUpload1.PostedFile.SaveAs(src);
                        src1 = "~/Pics/" + productid + ".JPG";
                    }
                    else if (ext1 == "JPEG")
                    {
                        src = Server.MapPath("Pics") +"/"+ productid + ".JPEG";
                        FileUpload1.PostedFile.SaveAs(src);
                        src1 = "~/Pics/" + productid + ".JPEG";
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
                con.dml("insert into products(productid,producttype,name,company,pettype,rate,netweight,stockquantity,picture)values('" + productid + "','" + txtpro.Text + "','" + txtname.Text + "','" + txtcomp.Text + "','" + txtpet.Text + "','" + txtrate.Text + "','" + txtnet.Text + "','" + txtstock.Text + "','" + src1 + "')");

                lblmsg.Text = "Successfully Added Products";

            }
            catch (Exception ee)
            {
                lblmsg.Text = "Failed";
                Response.Write(ee.ToString());
            }
        
        }
    
}