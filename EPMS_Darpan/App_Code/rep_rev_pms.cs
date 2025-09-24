using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for rep_rev_pms
/// </summary>
public class rep_rev_pms
{ 
   public rep_rev_pms()
	{
		
	}

    public void Insert(int unit_cd,string sail_pno, DateTime from_dt, DateTime to_dt, int rep_rev_cd,string rep_rev_spno,int ins_upd)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbCommand cmd = new OleDbCommand("insert_rep_rev_pms", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@unit_cd", OleDbType.Integer, 4, "unit_cd");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 8, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@from_dt", OleDbType.Date, 10, "from_dt");
        OleDbParameter p4 = new OleDbParameter("@to_dt", OleDbType.Date, 10, "to_dt");
        OleDbParameter p5 = new OleDbParameter("@rep_rev_cd", OleDbType.Integer,2, "rep_rev_cd");
        OleDbParameter p6 = new OleDbParameter("@rep_rev_spno", OleDbType.VarChar,8, "rep_rev_spno");
        
        OleDbParameter p7= new OleDbParameter("@ins_upd", OleDbType.Integer, 2, "ins_upd");
       
       
        p1.Value = unit_cd;
        p2.Value = sail_pno;
        p3.Value = from_dt;
        p4.Value = to_dt;
        p5.Value = rep_rev_cd;
        p6.Value = rep_rev_spno;
        p7.Value = ins_upd;
        //p8.Value = msg;
      
        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        //cmd.Parameters.Add(p8);
      
        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (OleDbException ex)
        { Displayerror(ex); }

        con.Close();
   }

    public void Insert1(int vyr, string sail_pno, DateTime from_dt, DateTime to_dt, int rep_rev_cd, string rep_rev_spno,string ent_by, int ins_upd)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbCommand cmd = new OleDbCommand("insert_rep_rev_pesb", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@vyr", OleDbType.Integer, 4, "xfinyr");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 8, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@from_dt", OleDbType.Date, 10, "from_dt");
        OleDbParameter p4 = new OleDbParameter("@to_dt", OleDbType.Date, 10, "to_dt");
        OleDbParameter p5 = new OleDbParameter("@rep_rev_cd", OleDbType.Integer, 2, "rep_rev_cd");
        OleDbParameter p6 = new OleDbParameter("@rep_rev_spno", OleDbType.VarChar, 8, "rep_rev_spno");
        OleDbParameter p7 = new OleDbParameter("@ent_by", OleDbType.VarChar, 8, "ent_by");
        OleDbParameter p8 = new OleDbParameter("@ins_upd", OleDbType.Integer, 2, "ins_upd");
        

        p1.Value = vyr;
        p2.Value = sail_pno;
        p3.Value = from_dt;
        p4.Value = to_dt;
        p5.Value = rep_rev_cd;
        p6.Value = rep_rev_spno;
        p7.Value = ent_by;
        p8.Value = ins_upd;
        

        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        cmd.Parameters.Add(p8);

        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (OleDbException ex)
        { Displayerror(ex); }

        con.Close();
    }


    public DataTable FetchAll(string sspno)
    {
        string sql = "Select rep_rev_spno,name,desig,dept,to_char(a.from_dt,'dd/mm/yyyy') from_dt,to_char(a.to_dt,'dd/mm/yyyy') to_dt,c.rep_rev_desc rep_rev_cd," +
                     "a.from_dt from_dt1 from rep_rev_pms a, emp_pms_v b,rep_rev_mas c where a.rep_rev_cd=c.rep_rev_cd and a.rep_rev_spno=b.sail_pno and  a.sail_pno= '" + sspno + "'" + "order by a.REP_REV_CD,from_dt1 asc";
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbDataAdapter da = new OleDbDataAdapter(sql,con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchAll1(string sspno, int  sfyr)
    {
        string sql = "Select rep_rev_pno,name,desig,dept,to_char(a.from_dt,'dd/mm/yyyy') from_dt,to_char(a.to_dt,'dd/mm/yyyy') to_dt,c.rep_rev_desc rep_rev_cd," +
                     "a.from_dt from_dt1 from rep_rev_pesb a, emp_pms_v b,rep_rev_mas c where a.rep_rev_cd=c.rep_rev_cd and a.rep_rev_pno=b.sail_pno and  a.sail_pno= '" + sspno + "'" + " and finyr =" +  sfyr + " order by a.REP_REV_CD,from_dt1 asc";
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void Displayerror(OleDbException exception)
    {
        string k;
        for (int i = 0; i < exception.Errors.Count; i++)
        {
            k = exception.Errors[i].Message;
        }
    }
}
