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
/// Summary description for funccls
/// </summary>
public class funcls
{
  // public string constring = "Provider=MSDAORA;Data Source=tcp.fois;Persist Security Info=True;User ID=pms;Unicode=True;Password=pms";
   // public OleDbConnection conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["constring"].ToString());
    public string constring = ConfigurationManager.ConnectionStrings["constring"].ToString();
    public int fun_cd
    {
        get
        {
            return fun_cd;
        }
        set
        {
            fun_cd = value;
        }
    }

    public string fun_desc
    {
        set
        {
            fun_desc = value;
        }
        get
        {
            return fun_desc;
        }
    }
    public string fun_abb
    {
        set
        {
            fun_abb = value;
        }
        get
        {
            return fun_abb;
        }
    }


    public funcls()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void Insertfun(int fun_cd, string fun_desc,string fun_abb)
    {
        string sql = "insert into func_mas(fun_cd,fun_desc,fun_abb) values (" + @fun_cd + ",'" + @fun_desc + "','" + @fun_abb + "')";

        OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();

    }

    public void Updatefun(int fun_cd, string fun_desc,string fun_abb )
    {
        string sql = "Update func_mas Set fun_desc='" + @fun_desc + "', fun_abb = '"+ @fun_abb+ "'  Where fun_cd=" + @fun_cd;

        OleDbConnection conn = new OleDbConnection(constring);
        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);

        cmd.Prepare();
        cmd.ExecuteNonQuery();

    }

    public void Deletefun(int fun_cd)
    {
        string sql = "Delete From func_mas Where fun_cd=" + @fun_cd;
        OleDbConnection conn = new OleDbConnection(constring);

        conn.Open();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        cmd.Prepare();
        cmd.ExecuteNonQuery();
        conn.Close();


    }

    public DataTable FetchAllfun()
    {
        string sql = "Select * from func_mas Order By fun_cd";
        OleDbDataAdapter da = new OleDbDataAdapter(sql, constring);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public DataTable FetchOnefun(int fun_cd)
    {
        string sql = "Select * from func_mas Where fun_cd=" + @fun_cd;
        OleDbDataAdapter da = new OleDbDataAdapter(sql, constring);
        DataTable dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

}
