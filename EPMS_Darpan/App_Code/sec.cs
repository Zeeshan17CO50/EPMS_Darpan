using System;
using System.Data;
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
/// Summary description for seccls
/// </summary>
public class seccls
{
   // public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
    public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public int sec_cd
    {
        get
        {
            return sec_cd;
        }
        set
        {
            sec_cd = value;
        }
    }

    public string sec_desc
    {
        set
        {
            sec_desc = value;
        }
        get
        {
            return sec_desc;
        }
    }
    public string sec_abb
    {
        set
        {
            sec_abb = value;
        }
        get
        {
            return sec_abb;
        }
    }


    public seccls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertsec(int sec_cd, string sec_desc, string sec_abb)
    {
        string sql = "insert into sec_mas(sec_cd,sec_desc,sec_abb) values (" + @sec_cd + ",'" + @sec_desc + "','" + @sec_abb + "')";

     //  OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updatesec(int sec_cd, string sec_desc, string sec_abb)
    {
        string sql = "Update sec_mas Set sec_desc='" + @sec_desc + "', sec_abb='" + @sec_abb + "'  Where sec_cd=" + @sec_cd;

      //  OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deletesec(int sec_cd)
    {
        string sql = "Delete From sec_mas Where sec_cd=" + @sec_cd;
       // OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAllsec()
    {
        string sql = "Select * from sec_mas Order By sec_cd";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOnesec(int sec_cd)
    {
        string sql = "Select * from sec_mas Where sec_cd=" + @sec_cd;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
