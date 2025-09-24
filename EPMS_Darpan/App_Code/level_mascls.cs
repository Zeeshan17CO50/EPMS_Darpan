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
/// Summary description for level_mascls
/// </summary>
public class level_mascls
{
    public string sail_pno
    {
        get
        {
            return sail_pno;
        }
        set
        {
            sail_pno = value;
        }
    }
    public string to_dt
    {
        get
        {
            return to_dt;
        }
        set
        {
            to_dt = value;
        }
    }
    public string from_dt
    {
        get
        {
            return from_dt;
        }
        set
        {
            from_dt = value;
        }
    }
	public level_mascls()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Insert(string sail_pno, DateTime from_dt, DateTime to_dt, int level_cd, int od_ind,int ins_upd,int trg_ind)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbCommand cmd = new OleDbCommand("ins_level_mas", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 8, "sail_pno");
        OleDbParameter p2 = new OleDbParameter("@from_dt", OleDbType.Date, 10, "from_dt");
        OleDbParameter p3 = new OleDbParameter("@to_dt", OleDbType.Date, 10, "to_dt");
        OleDbParameter p4 = new OleDbParameter("@level_cd", OleDbType.Integer, 2, "level_cd");
        OleDbParameter p5 = new OleDbParameter("@od_ind", OleDbType.Integer, 2, "od_ind");
        OleDbParameter p6 = new OleDbParameter("@ins_upd", OleDbType.Integer, 2, "ins_upd");
        OleDbParameter p7 = new OleDbParameter("@trg_ind", OleDbType.Integer, 2, "trg_ind");
        p1.Value = sail_pno;
        p2.Value = from_dt;
        p3.Value = to_dt;
        p4.Value = level_cd;
        p5.Value = od_ind;
        p6.Value = ins_upd;
        p7.Value = trg_ind;
        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (OleDbException ex)
        { Displayerror(ex); }

        con.Close();
    }
    public DataTable FetchAll()
    {
        string sql = "select a.sail_pno,name,desig,(dept||'('||unit||')') dept,to_char(from_dt,'dd/mm/yyyy') from_dt,to_char(to_dt,'dd/mm/yyyy') to_dt,level_des ,decode(OD_OFF_IND,1,'OD',2,'CCS') OD_OFF_IND,decode(trg_off_ind,1,'OD-Training',2,'HOT','') trg_off_ind from level_mas a, level_ind_mas b ,emp_pms_v c where a.level_cd=b.level_cd(+) and a.sail_pno=c.sail_pno";
      //  string sql = "select a.sail_pno,name,desig,dept,to_char(from_dt,'dd/mm/yyyy') from_dt,to_char(to_dt,'dd/mm/yyyy') to_dt,level_des, OD_OFF_IND from level_mas a, level_ind_mas b ,emp_pms_v c where a.level_cd=b.level_cd and a.sail_pno=c.sail_pno AND UNIT_CD=" + vunit_cd;
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }
    public void Updatelevel(string sail_pno, DateTime from_dt, DateTime to_dt, int level_cd, int od_ind, int ins_upd,int trg_ind)
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbCommand cmd = new OleDbCommand("ins_level_mas", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 8, "sail_pno");
        OleDbParameter p2 = new OleDbParameter("@from_dt", OleDbType.Date, 10, "from_dt");
        OleDbParameter p3 = new OleDbParameter("@to_dt", OleDbType.Date, 10, "to_dt");
        OleDbParameter p4 = new OleDbParameter("@level_cd", OleDbType.Integer, 2, "level_cd");
        OleDbParameter p5 = new OleDbParameter("@od_ind", OleDbType.Integer, 2, "od_ind");
        OleDbParameter p6 = new OleDbParameter("@ins_upd", OleDbType.Integer, 2, "ins_upd");
        OleDbParameter p7 = new OleDbParameter("@trg_ind", OleDbType.Integer, 2, "trg_ind");
        p1.Value = sail_pno;
        p2.Value = from_dt;
        p3.Value = to_dt;
        p4.Value = level_cd;
        p5.Value = od_ind;
        p6.Value = ins_upd;
        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);
        cmd.Parameters.Add(p4);
        cmd.Parameters.Add(p5);
        cmd.Parameters.Add(p6);
        cmd.Parameters.Add(p7);
        con.Open();
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (OleDbException ex)
        { Displayerror(ex); }

        con.Close();
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
