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
public class kpacls
{
    public OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public kpacls()
	{
		
	}

    public void Insert(int finyr, string sail_pno, int kpa_slno, string kpa_desc, decimal max_marks,int dept_cd,int unit_cd,string kpa_type,string ins_upd,string ent_pno)
    {      
        OleDbCommand cmd = new OleDbCommand("ins_kpa_mas", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@finyr", OleDbType.Integer, 4, "finyr");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 8, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@kpa_slno", OleDbType.Integer, 2, "kpa_slno");
        OleDbParameter p4 = new OleDbParameter("@kpa_desc", OleDbType.VarChar, 1000, "kpa_desc");
        OleDbParameter p5 = new OleDbParameter("@max_marks", OleDbType.Decimal, 5, "max_marks");
        OleDbParameter p6 = new OleDbParameter("@dept_cd", OleDbType.Integer, 5, "dept_cd");
        OleDbParameter p7 = new OleDbParameter("@unit_cd", OleDbType.Integer, 2 , "unit_cd");
        OleDbParameter p8 = new OleDbParameter("@kpa_type", OleDbType.Char, 1, "kpa_type");
        OleDbParameter p9 = new OleDbParameter("@ins_upd", OleDbType.Char,1, "ins_upd");
        OleDbParameter p10 = new OleDbParameter("@ent_pno", OleDbType.VarChar, 7, "ent_pno");

        p1.Value = finyr;
        p2.Value = sail_pno;
        p3.Value = kpa_slno;
        p4.Value = kpa_desc;
        p5.Value = max_marks;
        p6.Value = dept_cd;
        p7.Value = unit_cd;
        p8.Value = kpa_type;
        p9.Value = ins_upd;
        p10.Value = ent_pno;

        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        cmd.Parameters.Add(p8);
        cmd.Parameters.Add(p9);
        cmd.Parameters.Add(p10);

        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public DataTable FetchAll( int finyear,string sail_pno)
    {
        string sql = "Select kpa_slno,kpa_desc,max_marks,decode(kpa_type,'R','ROUTINE','N','NON-ROUTINE','S','SPECIAL') kpa_type,decode(to_char(nvl(cancel_dt,'01-jan-1900'),'dd/mm/yyyy'),'01/01/1900','',cancel_rem ||'(Cancelled on '||to_char(cancel_dt,'dd/mm/yyyy')||')') cancel_rem from kpa_mas where finyr=" + @finyear + " and sail_pno='" + @sail_pno + "' order by kpa_slno";
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
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

    //public decimal maxmm(int finyear, string sail_pno)
    //{
    //    string sql = "Select nvl(sum(max_marks),0) from kpa_mas where cancel_dt is null and sail_pno='" + sail_pno + "' and finyr=" + finyear;
    //    decimal dt = 0;
    //    OleDbCommand cmd = new OleDbCommand(sql, con);
    //    OleDbDataReader dr;
    //    con.Open();
    //    dr = cmd.ExecuteReader();
    //    dr.Read();
    //    if (dr.HasRows == true)
    //    dt = Convert.ToDecimal(dr.GetValue(0).ToString());
    //    con.Close();
    //    return dt;
    //}

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

    public bool activity_check(int finyear, string sail_pno)
    {
     // string sql = "Select count(1) from activity_det  where kpa_slno not in (select kpa_slno from kpa_mas  where sail_pno='" + sail_pno + "' and finyr=" + finyear + ") and sail_pno='" + sail_pno + "' and finyr=" + finyear;
       string sql = "Select count(1) from kpa_mas  where kpa_slno not in (select distinct kpa_slno from activity_det  where sail_pno='" + sail_pno + "' and finyr=" + finyear + ") and sail_pno='" + sail_pno + "' and finyr=" + finyear;
        bool dtyesno =false;
        int dt;
        OleDbCommand cmd = new OleDbCommand(sql, con);
        OleDbDataReader dr;
        con.Open();
        dr = cmd.ExecuteReader();
        dr.Read();
        if (dr.HasRows == true)
        {
            dt = Convert.ToInt16(dr.GetValue(0).ToString());
            if (dt > 0)
            {
                dtyesno = true;
            }
            else
            {
                dtyesno = false;
            }
        }
        con.Close();
        return dtyesno;
    }
}
