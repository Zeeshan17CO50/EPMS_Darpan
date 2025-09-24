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
public class loccls
{
    OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public int loc_cd
    {
        get
        {
            return loc_cd;
        }
        set
        {
            loc_cd = value;
        }
    }

    public string loc_desc
    {
        set
        {
            loc_desc = value;
        }
        get
        {
            return loc_desc;
        }
    }
    public string loc_abb
    {
        set
        {
            loc_abb = value;
        }
        get
        {
            return loc_abb;
        }
    }

    public string city_type
    {
        set
        {
            city_type = value;
        }
        get
        {
            return city_type;
        }
    }

    public loccls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertloc(int loc_cd, string loc_desc, string loc_abb, string city_type)
    {
        string sql = "insert into loc_mas(loc_cd,loc_desc,loc_abb,city_type) values (" + @loc_cd + ",'" + @loc_desc + "','" + @loc_abb + "','" + @city_type + "')";

        //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updateloc(int loc_cd, string loc_desc,string loc_abb,string city_type)
    {
        string sql = "Update loc_mas Set loc_desc='" + @loc_desc + "', loc_abb='" + @loc_abb + "',city_type='" + @city_type + "' Where loc_cd=" + @loc_cd;
        //OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deleteloc(int loc_cd)
    {
        string sql = "Delete From loc_mas Where loc_cd=" + @loc_cd;
        //OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAllloc()
    {
        string sql = "Select * from loc_mas Order By loc_cd";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOneloc(int loc_cd)
    {
        string sql = "Select * from loc_mas Where loc_cd=" + @loc_cd;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
