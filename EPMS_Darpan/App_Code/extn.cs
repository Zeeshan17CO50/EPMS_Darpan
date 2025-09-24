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
/// Summary description for loccls
/// </summary>
public class extncls
{
    //public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
  
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
    public string upto_dt
    {
        set
        {
            upto_dt = value;
        }
        get
        {
            return upto_dt;
        }
    }

    public string reason
    {
        set
        {
            reason = value;
        }
        get
        {
            return reason;
        }
    }

    public extncls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertextn(int finyr, string sail_pno, string upto_dt, string reason)
    {
        string sql = "insert into extn_mas(finyr,sail_pno,upto_dt,reason) values (" + @finyr + ",'" + @sail_pno + "',to_date('" + @upto_dt + "','dd/mm/yyyy'),'" + @reason + "')";

       // OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updateextn(int finyr, string sail_pno, string upto_dt, string reason)
    {
        string sql = "Update extn_mas Set sail_pno='" + @sail_pno + "'  Where finyr=" + @finyr;

       // OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deleteextn(int finyr,string sail_pno)
    {
        string sql = "Delete From extn_mas Where finyr=" + @finyr+"and sail_pno="+@sail_pno;
       // OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAllextn()
    {
        string sql = "Select * from extn_mas Order By finyr";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOneextn(int finyr)
    {
        string sql = "Select * from extn_mas Where finyr=" + @finyr;
       OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
