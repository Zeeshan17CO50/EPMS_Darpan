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
/// Summary description for perf_diary
/// </summary>
public class perf_diary
{
 // public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
     public OleDbConnection con= new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
   
    public int finyr
    {
        get
        {
            return finyr;
        }
        set
        {
            finyr = value;
        }
    }

    public string sail_pno
    {
        set
        {
            sail_pno = value;
        }
        get
        {
            return sail_pno;
        }
    }
    public int kpa_slno
    {
        get
        {
            return kpa_slno;
        }
        set
        {
            kpa_slno = value;
        }
    }

    public int slno
    {
        get
        {
            return slno;
        }
        set
        {
            slno = value;
        }
    }

    public string self_diary
    {
        set
        {
            self_diary = value;
        }
        get
        {
            return self_diary;
        }
    }
    public string rep_diary
    {
        get
        {
            return rep_diary;
        }
        set
        {
            rep_diary = value;
        }
    }

    public string self_ent_dt
    {
        set
        {
            self_ent_dt = value;
        }
        get
        {
            return self_ent_dt;
        }
    }
    public string rep_ent_dt
    {
        set
        {
            rep_ent_dt = value;
        }
        get
        {
            return rep_ent_dt;
        }
    }

    public string high_ind
    {
        set
        {
            high_ind = value;
        }
        get
        {
            return high_ind;
        }
    }

    public string ro_seen
    {
        set
        {
            ro_seen = value;
        }
        get
        {
            return ro_seen;
        }
    }

    public perf_diary()
    {

    }
    public void Insert(int finyr, string sail_pno, int kpa_slno, int slno, string self_diary, string rep_diary, string high_ind,string ro_seen,string self_ent_dt, string rep_ent_dt)
    {
       // OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
        OleDbCommand cmd = new OleDbCommand("insert_perf_diary", con);
        cmd.CommandType = CommandType.StoredProcedure;
        OleDbParameter p1 = new OleDbParameter("@finyr", OleDbType.Integer,4,"finyr");
        OleDbParameter p2 = new OleDbParameter("@sail_pno", OleDbType.VarChar, 8, "sail_pno");
        OleDbParameter p3 = new OleDbParameter("@kpa_slno", OleDbType.Integer,2, "kpa_slno");
        OleDbParameter p4 = new OleDbParameter("@slno", OleDbType.Integer, 2, "slno");
        OleDbParameter p5 = new OleDbParameter("@self_diary", OleDbType.VarChar, 1000, "self_diary");
        OleDbParameter p6 = new OleDbParameter("@rep_diary", OleDbType.VarChar,1000, "rep_diary");
        OleDbParameter p7 = new OleDbParameter("@high_ind", OleDbType.VarChar, 1, "high_ind");
        OleDbParameter p8 = new OleDbParameter("@ro_seen", OleDbType.VarChar, 1, "ro_seen");
        OleDbParameter p9 = new OleDbParameter("@self_ent_dt", OleDbType.VarChar,10, "self_ent_dt");
        OleDbParameter p10 = new OleDbParameter("@rep_ent_dt", OleDbType.VarChar, 10, "rep_ent_dt");
        p1.Value = finyr;
        p2.Value = sail_pno;
        p3.Value = kpa_slno;
        p4.Value = slno;
        p5.Value = self_diary;
        p6.Value = rep_diary;
        p7.Value = high_ind;
        p8.Value = ro_seen;
        p9.Value = self_ent_dt;
        p10.Value = rep_ent_dt;
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
    public void fetchrecord()
    {

    }
    public DataTable FetchAlldiary(int finyr,string sail_pno,int kpa_slno)
    {
        string sql = "Select * from perf_diary_mas where finyr="+finyr+" and sail_pno='"+sail_pno+"' and kpa_slno ="+kpa_slno+"  Order By slno";
        //string sql = "Select * from perf_diary_mas Order By slno";
        OleDbDataAdapter da = new OleDbDataAdapter(sql,con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchAlldiary_high(int finyr, string sail_pno, int kpa_slno)
    {
        string sql = "Select * from perf_diary_mas where finyr=" + finyr + " and sail_pno='" + sail_pno + "' and kpa_slno =" + kpa_slno + "and high_ind='Y' and ro_seen='N' Order By slno";
        //string sql = "Select * from perf_diary_mas Order By slno";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void Updatediary(string self_diary, string rep_diary, int finyr, string sail_pno, int kpa_slno, int slno, string high_ind, string ro_seen)
    {
        string sql = "Update perf_diary_mas Set self_diary='" + @self_diary + "',rep_diary='" + @rep_diary + "',high_ind='"+high_ind+"',ro_seen='"+ro_seen+"' Where finyr=" + @finyr + " and sail_pno='" + sail_pno + "' and kpa_slno=" + kpa_slno + " and slno=" + slno;

       /// OleDbConnection conn = new OleDbConnection(constring);
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Updatediary_seen(string self_diary, string rep_diary, int finyr, string sail_pno, int kpa_slno, int slno, string ro_seen)
    {
        string sql = "Update perf_diary_mas Set self_diary='" + @self_diary + "',rep_diary='" + @rep_diary + "',ro_seen='" + ro_seen + "' Where finyr=" + @finyr + " and sail_pno='" + sail_pno + "' and kpa_slno=" + kpa_slno + " and slno=" + slno;

       // OleDbConnection conn = new OleDbConnection(constring);
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Updatediary_oth(string self_diary, string rep_diary, int finyr, string sail_pno, int kpa_slno, int slno)
    {
        string sql = "Update perf_diary_mas Set rep_ent_dt=sysdate, self_diary='" + @self_diary + "',rep_diary='" + @rep_diary + "' Where finyr=" + @finyr + " and sail_pno='" + sail_pno + "' and kpa_slno=" + kpa_slno + " and slno=" + slno;

       //OleDbConnection conn = new OleDbConnection(constring);
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Deletediary(int finyr, string sail_pno, int kpa_slno, int slno)
    {
        string sql = "Delete from perf_diary_mas where finyr=" + @finyr + " and sail_pno='" + sail_pno + "' and kpa_slno=" + kpa_slno + " and slno=" + slno +  " and rep_diary is null and ro_seen ='N'";

       // OleDbConnection conn = new OleDbConnection(constring);
        con.Open();
        OleDbCommand cmd = new OleDbCommand(sql, con);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    //}
    //public DataTable FetchOnediary(int )
    //{
    //    string sql = "Select * from func_mas Where fun_cd=" + @fun_cd;
    //    OleDbDataAdapter da = new OleDbDataAdapter(sql, constring);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    return dt;
    //}
}
