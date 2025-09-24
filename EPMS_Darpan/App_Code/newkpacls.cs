using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for kpacls
/// </summary>
public class newkpacls
{
    public OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public newkpacls()
	{
		
	}

     

    public int maxslno(int finyear,string sail_pno)
    {
        string sql = "Select nvl(max(kpa_slno),0)+1 from kpa_mas where sail_pno='" + sail_pno + "' and finyr=" + finyear;
        int dt = 0;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
        con.Close();
        return dt;
    }

    public decimal maxmm(int finyear, string sail_pno, int kpa_set_no)
    {
        string sql = "Select nvl(sum(weightage),0) from new_kpa_mas where cancel_dt is null and sail_pno='" + sail_pno + "' and finyr=" + finyear + " and kpa_set_no =" + kpa_set_no ;
        decimal dt = 0;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        dt = Convert.ToDecimal(dr.GetValue(0).ToString());
        con.Close();
        return dt;
    }

    public Int16 maxkpsetno(int finyear, string sail_pno)
    {
        string sql = "Select nvl(max(nvl(kpa_set_no,0)),1) from new_kpa_mas where  sail_pno='" + sail_pno + "' and finyr=" + finyear;
        Int16 dt = 0;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
        con.Close();
        return dt;
    }

    public Int16 finrevkpsetno(int finyear, string sail_pno)
    {
        string sql = "Select min(nvl(kpa_set_no,0)) from new_pms_set_mas where  sail_pno='" + sail_pno + "' and finyr=" + finyear + " and sysdate >=final_st_dt";
        Int16 dt = 0;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
          con.Close();
        return dt;
    }

    public Int16 assesskpasetno(int finyear, string sail_pno)
    {
        string sql = "Select nvl(max(nvl(kpa_set_no,0)),0) from new_pms_status_prn where  sail_pno='" + sail_pno + "' and finyr=" + finyear ;
        Int16 dt = 0;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
        con.Close();
        return dt;
    }


    public decimal maxmmedit(int finyear, string sail_pno,int kpa_slno)
    {
        string sql = "Select nvl(sum(max_marks),0) from kpa_mas where cancel_dt is null and sail_pno='" + sail_pno + "' and finyr=" + finyear+" and kpa_slno!="+kpa_slno;
        decimal dt = 0;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
            dt = Convert.ToDecimal(dr.GetValue(0).ToString());
        con.Close();
        return dt;
    }

    
}
