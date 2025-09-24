using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for maxslno
/// </summary>
public class maxslno
{
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
	public maxslno()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int maxcnt(string tbl_nm,string fld_nm)    
    {
        int z = 0;
        string sql = "Select nvl(max("+fld_nm+"),0)+1 from " +tbl_nm;
        //OleDbConnection conn = new OleDbConnection(constring);
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();

        OleDbDataReader dr;

        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {

            z = Convert.ToInt16(dr.GetValue(0));
        }
        conn.Close();
        return (z);

    }
}
