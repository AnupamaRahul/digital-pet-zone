    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for connect
/// </summary>
public class connect
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader dr;
    public SqlDataAdapter da;
    public DataSet ds;
	public connect()
	{
        con=new SqlConnection("server=.;uid=sa;pwd=abcd;database=digitalpetzone");
        cmd = new SqlCommand();
		//
		// TODO: Add constructor logic here
		//
	}
    public void start()
    {
        if(con.State==ConnectionState.Open)
        {
            con.Close();
            con.Open();
            cmd.Connection = con;

        }
    else
        {
            con.Open();
            cmd.Connection = con;
        }
    }
public void dml(string sql)
    {
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public DataSet fill(string sql)
{
    da = new SqlDataAdapter(sql, con);
    ds = new DataSet();
    da.Fill(ds, "data");
    return ds;
}
   
    public SqlDataReader read(string sql)
    {
        cmd.CommandText = sql;
        return cmd.ExecuteReader();
    }
}