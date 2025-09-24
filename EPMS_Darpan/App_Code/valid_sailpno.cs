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
/// Summary description for valid_sailpno
/// </summary>
public class valid_sailpno
{
    public OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
	public valid_sailpno()
	{
    }
    public bool validpno(string pno,int xunit_cd)
    {
        bool sailpno = false;
        string sql = "select sail_pno from emp_pms_v where sail_pno='" +pno+ "'";
        //and unit_cd="+xunit_cd  ;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            sailpno = true;
        }
        con.Close();
        return (sailpno);
       
    }
    public bool validpno_nounit(string pno)
    {
        bool sailpno = false;
        string sql = "select sail_pno from emp_pms_v where sail_pno='" + pno + "'";
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            sailpno = true;
        }
        con.Close();
        return (sailpno);

    }
}
